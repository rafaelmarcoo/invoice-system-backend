using System.ComponentModel.DataAnnotations;

namespace invoice_system_backend.Models
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public float Quantity { get; set; }

        public float Price { get; set; }

        public int InvoiceId { get; set; }
    }
}
