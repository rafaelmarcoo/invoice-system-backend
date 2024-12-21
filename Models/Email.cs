namespace invoice_system_backend.Models
{
    public class Email
    {
        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public IFormFile File { get; set; }

        public string FileName { get; set; }
    }
}
