namespace invoice_system_backend.Models
{
    public class Invoice
    {
        public string InvoiceCode { get; set; }
        public string Name { get; set; }
        public DateOnly DateSent { get; set; }
        public DateOnly DateDue { get; set; }
        public int Amount { get; set; }
        public int GST { get; set; }
        public bool IsPaid { get; set; }
        public bool IsRecurring { get; set; }
    }
}
