using OticaCrista.Models.Enums;

namespace OticaCrista.Models.Sale
{
    public class Entry
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PaymentDate { get; set; }
        public EntryStatus Status { get; set; }

    }
}
