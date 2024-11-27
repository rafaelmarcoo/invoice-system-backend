using System.ComponentModel.DataAnnotations;

namespace invoice_system_backend.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
