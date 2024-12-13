namespace invoice_system_backend.Models
{
    public class Asset
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string DatePurchased { get; set; }

        public string DepreciationType { get; set; }

        public decimal DepreciationRate { get; set; }

        public decimal OriginalValue { get; set; }

        public int UsefulLife { get; set; }

    }
}
