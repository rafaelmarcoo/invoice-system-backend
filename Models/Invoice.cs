using System.ComponentModel.DataAnnotations;

namespace invoice_system_backend.Models
{
    public class Invoice
    {
        [Key]
        [Required]
        public string InvoiceCode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly DateSent { get; set; }

        [Required]
        public DateOnly DateDue { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int GST { get; set; }

        public bool IsPaid { get; set; }

        public bool IsRecurring { get; set; }
    }
}
