namespace invoice_system_backend.Models
{
    public class DepreciationData
    {
        public int Year { get; set; }

        public decimal OriginalValue { get; set; }

        public decimal DepreciationRate { get; set; }

        public decimal DepreciationClaimed { get; set; }

        public decimal AdjustedTaxValue { get; set; }
    }
}
