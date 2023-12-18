using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class DoktorlarTablosu
    {
        [Key]
        public int DoktorId { get; set; }

        [Required]
        public string DoktorAdi { get; set; }

        [Required]
        public string Uzmanlik { get; set; }

        [Required]
        public string GunHafta { get; set; }

        [Required]
        public TimeSpan BaslamaSaati { get; set; }

        [Required]
        public TimeSpan BitisSaati { get; set; }

    }
}
