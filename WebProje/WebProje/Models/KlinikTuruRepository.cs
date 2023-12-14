using System.Linq.Expressions;
using WebProje.Utility;

namespace WebProje.Models
{
    public class KlinikTuruRepository : Repository<KlinikTuru>, IKlinikTuruRepository
    {
        private HastaneRandevuDbContext _hastaneRandevuDbContext;
        public KlinikTuruRepository(HastaneRandevuDbContext hastaneRandevuDbContext) : base(hastaneRandevuDbContext)
        {
            _hastaneRandevuDbContext = hastaneRandevuDbContext;
        }

        public void Guncelle(KlinikTuru klinikTuru)
        {
            _hastaneRandevuDbContext.Update(klinikTuru);
        }

        public void Kaydet()
        {
            _hastaneRandevuDbContext.SaveChanges();
        }
    }
}
