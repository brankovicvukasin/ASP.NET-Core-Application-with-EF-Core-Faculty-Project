namespace WebProj.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public ApplicationContext(DbContextOptions op)
            : base(op) { }
    }
}
