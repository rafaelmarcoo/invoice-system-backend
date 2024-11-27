namespace invoice_system_backend.Models
{
    public class Expense
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public DateOnly Date { get; set; }
        public int Amount { get; set; }
    }
}
