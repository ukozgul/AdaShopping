using AdaShopping.Models;
using Microsoft.EntityFrameworkCore;

namespace AdaShopping.Data
{
    public class AdaDbContext : DbContext
    {
        public AdaDbContext(DbContextOptions<AdaDbContext> options)
            : base(options)
        {

        }

        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Sepet> Sepetler { get; set; }
        public DbSet<SepetUrun> SepetUrunler { get; set; }

    }
}
