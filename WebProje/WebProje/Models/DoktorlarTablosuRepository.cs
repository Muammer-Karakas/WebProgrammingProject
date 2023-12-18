using System.Linq.Expressions;
using WebProje.Utility;

namespace WebProje.Models
{
    public class DoktorlarTablosuRepository : Repository<DoktorlarTablosu>, IDoktorlarTablosuRepository
    {
        private HastaneRandevuDbContext _hastaneRandevuDbContext;
        public DoktorlarTablosuRepository(HastaneRandevuDbContext hastaneRandevuDbContext) : base(hastaneRandevuDbContext)
        {
            _hastaneRandevuDbContext = hastaneRandevuDbContext;
        }

        public void Guncelle(DoktorlarTablosu doktorlarTablosu)
        {
            _hastaneRandevuDbContext.Update(doktorlarTablosu);
        }

        public void Kaydet()
        {
            _hastaneRandevuDbContext.SaveChanges();
        }
    }
}
