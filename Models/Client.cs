﻿using System.ComponentModel.DataAnnotations;

namespace invoice_system_backend.Models
{
    public class Client
    {
        [Key]
        [Required]
        public string InvoiceCode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        
    }
}
