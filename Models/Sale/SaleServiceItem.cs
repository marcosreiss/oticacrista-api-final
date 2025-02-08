namespace OticaCrista.Models.Sale
{
    public class SaleServiceItem
    {
        public int Id { get; set; }


        public int ServiceId { get; set; }
        public ServiceModel Service { get; set; } = null!;


        public int Amount { get; set; }
        public double Discount { get; set; }
        public double FinalPrice { get; set; }
        public string? Observation { get; set; }


        public SaleModel Sale { get; set; } = null!;
        public int SaleId { get; set; }
    }
}
