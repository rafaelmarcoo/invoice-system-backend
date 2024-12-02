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
        public DateOnly Date_Sent { get; set; }

        [Required]
        public DateOnly Date_Due { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public bool IsPaid { get; set; }
    }
}
