namespace Supplier_API_1.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string  ProductCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
