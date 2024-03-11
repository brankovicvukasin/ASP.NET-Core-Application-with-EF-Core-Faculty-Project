namespace WebProj.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public Company? Company { get; set; }
    }
}
