namespace WebProje.Models
{
    public interface IKlinikTuruRepository : IRepository<KlinikTuru>
    {
        void Guncelle(KlinikTuru klinikTuru);
        void Kaydet();
    }
}
