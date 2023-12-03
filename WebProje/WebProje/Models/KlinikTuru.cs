using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class KlinikTuru
    {
        [Key]
        public int KlinikTuruId { get; set; }

        [Required]
        public string Ad {  get; set; }
    }
}
