using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplier_API_2.Models
{
    public class QuoteItem
    {
        [Key]
        public int QuoteItemId { get; set; }

        public string ProductCode { get; set; }

        public int Amount { get; set; }

        [ForeignKey("Quote")]
        public int QuoteId { get; set; }

    }
}
