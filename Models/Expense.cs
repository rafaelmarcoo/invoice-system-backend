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

        public string FilePath { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public float Amount { get; set; }

        public string Category { get; set; }

        public float GstRate { get; set; }
    }
}
