using System.Linq.Expressions;

namespace WebProje.Models
{
    public interface IRepository<K> where K : class        //K => klinik türü
    {
        IEnumerable<K> GetAll();

        K Get(Expression<Func<K,bool>> filtre);

        void Ekle(K entity);
        void Sil(K entity);
        void AraligiSil(IEnumerable<K> entities);
        
    }
}

