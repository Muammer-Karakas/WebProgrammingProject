using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebProje.Utility;

namespace WebProje.Models
{
    public class Repository<K> : IRepository<K> where K : class
    {
        private readonly HastaneRandevuDbContext _hastaneRandevuDbContext;
        internal DbSet<K> dbSet;
        
        public Repository(HastaneRandevuDbContext hastaneRandevuDbContext)
        {
            _hastaneRandevuDbContext = hastaneRandevuDbContext;
            this.dbSet = _hastaneRandevuDbContext.Set<K>();
        }


        public void Ekle(K entity)
        {
            dbSet.Add(entity);
        }

        public K Get(Expression<Func<K, bool>> filtre)
        {
            IQueryable<K> getir = dbSet;
            getir = getir.Where(filtre);
            return getir.FirstOrDefault();
        }

        public IEnumerable<K> GetAll()
        {
            IQueryable<K> getir = dbSet;
            return getir.ToList();
        }

        public void Sil(K entity)
        {
            dbSet.Remove(entity);
        }

        public void AraligiSil(IEnumerable<K> entities)
        {
            dbSet.RemoveRange(entities);
        }

      
    }
}
