using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TechFixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(HttpClient httpClient, ILogger<SupplierController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetSupplierProducts()
        {
            string supplier1ApiUrl = "https://localhost:44339/api/Products";
            string supplier2ApiUrl = "https://localhost:44380/api/Products";

            HttpResponseMessage supplierResponse1 = await _httpClient.GetAsync(supplier1ApiUrl);
            HttpResponseMessage supplierResponse2 = await _httpClient.GetAsync(supplier2ApiUrl);

            if (!supplierResponse1.IsSuccessStatusCode || !supplierResponse2.IsSuccessStatusCode)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error retrieving data from one or both of the supplier APIs.");
            }

            var supplier1Data = await supplierResponse1.Content.ReadAsStringAsync();
            var supplier2Data = await supplierResponse2.Content.ReadAsStringAsync();

            // Parse JSON arrays
            JArray supplier1Array;
            JArray supplier2Array;
            try
            {
                supplier1Array = JArray.Parse(supplier1Data);
                supplier2Array = JArray.Parse(supplier2Data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Error parsing JSON data: {ex.Message}");
            }

            var combinedResponse = new JObject
            {
                ["supplier1"] = supplier1Array,
                ["supplier2"] = supplier2Array
            };

            return Content(combinedResponse.ToString(), "application/json");
        }

        [HttpGet("product/{productname}")]
        public async Task<IActionResult> GetSingleProductData(string productname)
        {
            string supplier1ApiUrl = $"https://localhost:44339/api/Products/details/{productname}";
            string supplier2ApiUrl = $"https://localhost:44380/api/Products/details/{productname}";

            HttpResponseMessage supplierResponse1 = null;
            HttpResponseMessage supplierResponse2 = null;

            try
            {
                supplierResponse1 = await _httpClient.GetAsync(supplier1ApiUrl);
            }
            catch (Exception ex)
            {
                // Log the exception for supplier 1
            }

            try
            {
                supplierResponse2 = await _httpClient.GetAsync(supplier2ApiUrl);
            }
            catch (Exception ex)
            {
                // Log the exception for supplier 2
            }

            JArray supplier1Array = null;
            JArray supplier2Array = null;

            if (supplierResponse1 != null && supplierResponse1.IsSuccessStatusCode)
            {
                var supplier1Data = await supplierResponse1.Content.ReadAsStringAsync();
                try
                {
                    supplier1Array = JArray.Parse(supplier1Data);
                }
                catch (Exception ex)
                {
                    // Handle JSON parsing error for supplier 1
                }
            }

            if (supplierResponse2 != null && supplierResponse2.IsSuccessStatusCode)
            {
                var supplier2Data = await supplierResponse2.Content.ReadAsStringAsync();
                try
                {
                    supplier2Array = JArray.Parse(supplier2Data);
                }
                catch (Exception ex)
                {
                }
            }

            if (supplier1Array == null && supplier2Array == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error retrieving data from both suppliers.");
            }

            var combinedResponse = new JObject();

            if (supplier1Array != null)
            {
                combinedResponse["supplier1"] = supplier1Array;
            }

            if (supplier2Array != null)
            {
                combinedResponse["supplier2"] = supplier2Array;
            }

            return Content(combinedResponse.ToString(), "application/json");
        }

        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder([FromBody] List<Item> orderItems)
        {
            _logger.LogInformation("=======================================");
            _logger.LogInformation("Place Order");
            _logger.LogInformation("=======================================");
            if (orderItems == null || !orderItems.Any())
            {
                return BadRequest("Order cannot be empty.");
            }

            if (orderItems.Count > 10)
            {
                return BadRequest("Order cannot have more than 10 items.");
            }

            List<JObject> supplier1OrderItems = new List<JObject>();
            List<JObject> supplier2OrderItems = new List<JObject>();

            foreach (var item in orderItems)
            {
                var supplier = item.Supplier;

                if (supplier == "supplier1")
                {
                    supplier1OrderItems.Add(new JObject
                    {
                        { "productCode", item.ProductCode },
                        { "amount", item.Amount }
                    });
                }
                else if (supplier == "supplier2")
                {
                    supplier2OrderItems.Add(new JObject
                    {
                        { "productCode", item.ProductCode },
                        { "amount", item.Amount }
                    });
                }
                else
                {
                    return BadRequest("Invalid supplier specified.");
                }
            }

            JObject combinedResponse = new JObject();
            HttpResponseMessage supplier1Response = null;
            HttpResponseMessage supplier2Response = null;

            if (supplier1OrderItems.Count > 0)
            {
                var supplier1Order = new JObject
                {
                    ["order"] = new JObject
                    {
                        ["status"] = "Pending",
                        ["orderItems"] = new JArray(supplier1OrderItems)
                    }
                };

                _logger.LogInformation("=======================================");
                _logger.LogInformation("Supplier 1 order object: {Supplier1Order}", supplier1Order.ToString());
                _logger.LogInformation("=======================================");

                var supplier1ApiUrl = "https://localhost:44339/api/Orders/place";
                var content = new StringContent(supplier1Order.ToString(), Encoding.UTF8, "application/json");

                try
                {
                    supplier1Response = await _httpClient.PostAsync(supplier1ApiUrl, content);
                    if (supplier1Response.IsSuccessStatusCode)
                    {
                        var supplier1ResponseData = await supplier1Response.Content.ReadAsStringAsync();
                        combinedResponse["supplier1OrderResponse"] = JObject.Parse(supplier1ResponseData);
                    }
                    else
                    {
                        combinedResponse["supplier1OrderResponse"] = $"Supplier 1 order failed with status {supplier1Response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    combinedResponse["supplier1OrderResponse"] = $"Error placing order with Supplier 1: {ex.Message}";
                }
            }

            if (supplier2OrderItems.Count > 0)
            {
                var supplier2Order = new JObject
                {
                    ["order"] = new JObject
                    {
                        ["status"] = "Pending",
                        ["orderItems"] = new JArray(supplier2OrderItems)
                    }
                };

                _logger.LogInformation("=======================================");
                _logger.LogInformation("Supplier 2 order object: {Supplier2Order}", supplier2Order.ToString());
                _logger.LogInformation("=======================================");

                var supplier2ApiUrl = "https://localhost:44380/api/Orders/place";
                var content = new StringContent(supplier2Order.ToString(), Encoding.UTF8, "application/json");

                try
                {
                    supplier2Response = await _httpClient.PostAsync(supplier2ApiUrl, content);
                    if (supplier2Response.IsSuccessStatusCode)
                    {
                        var supplier2ResponseData = await supplier2Response.Content.ReadAsStringAsync();
                        combinedResponse["supplier2OrderResponse"] = JObject.Parse(supplier2ResponseData);
                    }
                    else
                    {
                        combinedResponse["supplier2OrderResponse"] = $"Supplier 2 order failed with status {supplier2Response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    combinedResponse["supplier2OrderResponse"] = $"Error placing order with Supplier 2: {ex.Message}";
                }
            }

            if (supplier1Response == null && supplier2Response == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Failed to place order with any supplier.");
            }

            return Content(combinedResponse.ToString(), "application/json");
        }

        [HttpPost("RequestQuote")]
        public async Task<IActionResult> RequestQuote([FromBody] List<Item> quoteItems)
        {
            if (quoteItems == null || !quoteItems.Any())
            {
                return BadRequest("Quote cannot be empty.");
            }

            if (quoteItems.Count > 10)
            {
                return BadRequest("Quote cannot have more than 10 items.");
            }

            List<JObject> supplier1QuoteItems = new List<JObject>();
            List<JObject> supplier2QuoteItems = new List<JObject>();

            foreach (var item in quoteItems)
            {
                var supplier = item.Supplier;

                if (supplier == "supplier1")
                {
                    supplier1QuoteItems.Add(new JObject
                    {
                        { "productCode", item.ProductCode },
                        { "amount", item.Amount }
                    });
                }
                else if (supplier == "supplier2")
                {
                    supplier2QuoteItems.Add(new JObject
                    {
                        { "productCode", item.ProductCode },
                        { "amount", item.Amount }
                    });
                }
                else
                {
                    return BadRequest("Invalid supplier specified.");
                }
            }

            JObject combinedResponse = new JObject();
            HttpResponseMessage supplier1Response = null;
            HttpResponseMessage supplier2Response = null;

            if (supplier1QuoteItems.Count > 0)
            {
                var supplier1Quote = new JObject
                {
                    ["quote"] = new JObject
                    {
                        ["status"] = "Pending",
                        ["quoteItems"] = new JArray(supplier1QuoteItems)
                    }
                };

                var supplier1ApiUrl = "https://localhost:44339/api/Quotes/place";
                var content = new StringContent(supplier1Quote.ToString(), Encoding.UTF8, "application/json");

                try
                {
                    supplier1Response = await _httpClient.PostAsync(supplier1ApiUrl, content);

                    if (supplier1Response.IsSuccessStatusCode)
                    {
                        var supplier1ResponseData = await supplier1Response.Content.ReadAsStringAsync();
                        combinedResponse["supplier1QuoteResponse"] = JObject.Parse(supplier1ResponseData);
                    }
                    else
                    {
                        combinedResponse["supplier1QuoteResponse"] = $"Supplier 1 quote failed with status {supplier1Response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    combinedResponse["supplier1QuoteResponse"] = $"Error placing quote with Supplier 1: {ex.Message}";
                }
            }

            if (supplier2QuoteItems.Count > 0)
            {
                var supplier2Quote = new JObject
                {
                    ["quote"] = new JObject
                    {
                        ["status"] = "Pending",
                        ["quoteItems"] = new JArray(supplier2QuoteItems)
                    }
                };
            
                var supplier2ApiUrl = "https://localhost:44380/api/Quotes/place";
                var content = new StringContent(supplier2Quote.ToString(), Encoding.UTF8, "application/json");

                try
                {
                    supplier2Response = await _httpClient.PostAsync(supplier2ApiUrl, content);

                    if (supplier2Response.IsSuccessStatusCode)
                    {
                        var supplier2ResponseData = await supplier2Response.Content.ReadAsStringAsync();
                        combinedResponse["supplier2QuoteResponse"] = JObject.Parse(supplier2ResponseData);
                    }
                    else
                    {
                        combinedResponse["supplier2QuoteResponse"] = $"Supplier 2 quote failed with status {supplier2Response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    combinedResponse["supplier2QuoteResponse"] = $"Error placing quote with Supplier 2: {ex.Message}";
                }
            }

            if (supplier1Response == null && supplier2Response == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Failed to place quote with any supplier.");
            }

            return Content(combinedResponse.ToString(), "application/json");
        }

    }
}

public class Item
{
    public string ProductCode { get; set; }
    public int Amount { get; set; }
    public string Supplier { get; set; }
}
