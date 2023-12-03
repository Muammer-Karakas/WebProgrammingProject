using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Utility
{
    public class HastaneRandevuDbContext : DbContext
    {
        public HastaneRandevuDbContext(DbContextOptions<HastaneRandevuDbContext> options) : base(options) { }

        public DbSet<KlinikTuru> KlinikTurleri { get; set; }
        
    }
}
