using System.ComponentModel.DataAnnotations;

namespace invoice_system_backend.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Frequency { get; set; }

        [Required]
        public string DateSent { get; set; }

        [Required]
        public string DateDue { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; } = "Sent";

        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }
}
