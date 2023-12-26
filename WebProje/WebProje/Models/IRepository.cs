using System.Linq.Expressions;

namespace WebProje.Models
{
    public interface IRepository<K> where K : class        //K => klinik türü
    {
        IEnumerable<K> GetAll(string? includeProps = null);

        K Get(Expression<Func<K,bool>> filtre, string? includeProps = null);

        void Ekle(K entity);
        void Sil(K entity);
        void AraligiSil(IEnumerable<K> entities);
        
    }
}

