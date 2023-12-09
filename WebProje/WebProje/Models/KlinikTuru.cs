using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class KlinikTuru
    {
        [Key]       //primary key
        public int KlinikTuruId { get; set; }

        [Required] 
        [DisplayName("Klinik Adı")]
        public string Ad {  get; set; }
    }
}
