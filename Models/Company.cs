using System.ComponentModel.DataAnnotations;

namespace invoice_system_backend.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "GST Number is required")]
        public string GST { get; set; }

        [Required(ErrorMessage = "Company Address Number is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Company City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Company Zip is required")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Company Phone is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Company Email is required")]
        public string Email { get; set; }
    }
}
