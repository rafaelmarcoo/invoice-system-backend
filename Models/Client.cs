using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace invoice_system_backend.Models
{
    public class Client
    {
        [Key]
        public string Company_Code { get; set; }

        [Required]
        public string GST_Number { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Phone { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}
