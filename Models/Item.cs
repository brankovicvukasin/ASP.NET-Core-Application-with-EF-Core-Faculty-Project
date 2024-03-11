namespace WebProj.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public required int Volume { get; set; }
        public int Weight { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public Company? Company { get; set; }
    }
}
