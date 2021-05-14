using Microsoft.EntityFrameworkCore;

namespace TP_Web.Models
{
    public class ContexteAutoLoco : DbContext, ReadMe
    {
        public ContexteAutoLoco(DbContextOptions<ContexteAutoLoco> p_options) : base(p_options) { }

        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<Succursale> Succursales { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
