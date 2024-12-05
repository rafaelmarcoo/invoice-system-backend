using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace invoice_system_backend.Models
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
    }
}
