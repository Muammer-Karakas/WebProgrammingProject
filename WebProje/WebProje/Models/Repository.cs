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
            _hastaneRandevuDbContext.DoktorlarTablosu.Include(k => k.KlinikTuru).Include(k => k.KlinikId);
        }


        public void Ekle(K entity)
        {
            dbSet.Add(entity);
        }

        public K Get(Expression<Func<K, bool>> filtre, string? includeProps = null)
        {
            IQueryable<K> getir = dbSet;
            getir = getir.Where(filtre);

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    getir = getir.Include(includeProp);
                }
            }

            return getir.FirstOrDefault();
        }

        public IEnumerable<K> GetAll(string? includeProps = null)
        {
            IQueryable<K> getir = dbSet;
            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach(var includeProp in includeProps.Split(new char[] {','} , StringSplitOptions.RemoveEmptyEntries))
                {
                    getir=getir.Include(includeProp);
                }
            }


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
