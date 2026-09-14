using Supplier_API_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Supplier_API_2.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }

        public DateTime QuoteDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";

        public List<QuoteItem> QuoteItems { get; set; } = new List<QuoteItem>();
    }
}
