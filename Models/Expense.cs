using System.ComponentModel.DataAnnotations;

namespace invoice_system_backend.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string? File { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
