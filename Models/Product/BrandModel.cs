namespace OticaCrista.Models.Product
{
    public class BrandModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ProductModel>? Products { get; set; } = new List<ProductModel>();
    }
}
