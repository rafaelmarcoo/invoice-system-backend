namespace invoice_system_backend.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
