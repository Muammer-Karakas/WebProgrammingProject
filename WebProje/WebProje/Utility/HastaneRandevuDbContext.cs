using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Utility
{
    public class HastaneRandevuDbContext : IdentityDbContext
    {
        public HastaneRandevuDbContext(DbContextOptions<HastaneRandevuDbContext> options) : base(options) { }

        public DbSet<KlinikTuru> KlinikTurleri { get; set; }

        public DbSet<DoktorlarTablosu> DoktorlarTablosu { get; set; }

        public DbSet<Randevu> Randevular { get; set; }

    }

}
