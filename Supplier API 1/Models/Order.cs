using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Supplier_API_1.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
