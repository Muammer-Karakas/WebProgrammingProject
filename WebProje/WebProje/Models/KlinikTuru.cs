using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class KlinikTuru
    {
        [Key]       //primary key
        public int KlinikTuruId { get; set; }

        [Required(ErrorMessage ="Bu alan boş bırakılamaz!")]
        [MaxLength(25)]
        [DisplayName("Klinik Adı")]
        public string Ad {  get; set; }
    }
}
