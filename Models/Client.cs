using System.IO.Compression;

namespace invoice_system_backend.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string InvoiceCode { get; set; }
    }
}
