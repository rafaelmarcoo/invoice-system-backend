using System.ComponentModel.DataAnnotations;

namespace invoice_system_backend.Models
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string DatePurchased { get; set; }

        [Required]
        public string DepreciationType { get; set; }

        [Required]
        public decimal DepreciationRate { get; set; }

        [Required]
        public decimal OriginalValue { get; set; }

        [Required]
        public int UsefulLife { get; set; }

    }
}
