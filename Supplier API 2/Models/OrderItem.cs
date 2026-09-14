using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplier_API_2.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public string ProductCode { get; set; }

        public int Amount { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

    }
}
