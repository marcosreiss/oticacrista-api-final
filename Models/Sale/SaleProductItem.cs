using OticaCrista.Models.Product;

namespace OticaCrista.Models.Sale
{
    public class SaleProductItem
    {
        public int Id { get; set; }


        public int ProductId { get; set; }
        public ProductModel Product { get; set; } = null!;


        public int Amount { get; set; }
        public double Discount { get; set; }
        public double FinalPrice { get; set; }
        public string? Observation { get; set; }


        public SaleModel Sale { get; set; } = null!;
        public int SaleId { get; set; }
    }
}
