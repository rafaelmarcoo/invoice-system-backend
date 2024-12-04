using System.ComponentModel.DataAnnotations;

namespace invoice_system_backend.Models
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public int InvoiceId { get; set; }
    }
}
