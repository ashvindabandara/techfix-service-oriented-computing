using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TechFixFrontend
{
    public partial class CheckStock : Form
    {
        private HttpClient _httpClient;

        public CheckStock()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string productname = textBox1.Text;

            string apiUrl = $"https://localhost:44346/api/Supplier/product/{productname}";
            try
            {
                var response = await _httpClient.GetStringAsync(apiUrl);

                var products = JsonConvert.DeserializeObject<SupplierProducts>(response);

                if (products.Supplier1.Count > 0)
                {
                    var supplier1Product = products.Supplier1[0];
                    labelSupplier1Name.Text = $"Name: {supplier1Product.Name}";
                    labelSupplier1Price.Text = $"Price: {supplier1Product.Price:C}";
                    labelSupplier1Stock.Text = $"Stock: {supplier1Product.Stock}";
                }

                if (products.Supplier2.Count > 0)
                {
                    var supplier2Product = products.Supplier2[0];
                    labelSupplier2Name.Text = $"Name: {supplier2Product.Name}";
                    labelSupplier2Price.Text = $"Price: {supplier2Product.Price:C}";
                    labelSupplier2Stock.Text = $"Stock: {supplier2Product.Stock}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching stock data: {ex.Message}");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void labelSupplier2Stock_Click(object sender, EventArgs e)
        {

        }
    }
}

public class Product
{
    public int Id { get; set; }
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public class SupplierProducts
{
    public List<Product> Supplier1 { get; set; }
    public List<Product> Supplier2 { get; set; }
}