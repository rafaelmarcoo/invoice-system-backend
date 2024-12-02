﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace invoice_system_backend.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string CompanyCode { get; set; }

        [Required]
        public string GstNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        //public List<Invoice> Invoices { get; set; }
    }
}
