namespace WebProje.Models
{
    public interface IDoktorlarTablosuRepository : IRepository<DoktorlarTablosu>
    {
        void Guncelle(DoktorlarTablosu doktorlarTablosu);
        void Kaydet();
    }
}
