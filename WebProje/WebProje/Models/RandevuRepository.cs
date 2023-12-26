using System.Linq.Expressions;
using WebProje.Utility;

namespace WebProje.Models
{
    public class RandevuRepository : Repository<Randevu>, IRandevuRepository
    {
        private HastaneRandevuDbContext _hastaneRandevuDbContext;
        public RandevuRepository(HastaneRandevuDbContext hastaneRandevuDbContext) : base(hastaneRandevuDbContext)
        {
            _hastaneRandevuDbContext = hastaneRandevuDbContext;
        }

        public void Guncelle(Randevu randevu)
        {
            _hastaneRandevuDbContext.Update(randevu);
        }

        public void Kaydet()
        {
            _hastaneRandevuDbContext.SaveChanges();
        }
    }
}
