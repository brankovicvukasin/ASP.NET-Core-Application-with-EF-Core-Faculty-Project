using System.Text.Json.Serialization;

namespace WebProj.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AverageEarnings { get; set; }
        public int NumberOfDaysForDelivery { get; set; }
        public int Price { get; set; }

        [JsonIgnore]
        public List<Vehicle>? Vehicles { get; set; }

        [JsonIgnore]
        public List<Item>? Items { get; set; }
    }
}
