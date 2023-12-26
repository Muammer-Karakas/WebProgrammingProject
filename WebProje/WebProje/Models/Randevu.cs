using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuId { get; set; }

        [Required]
        public int HastaId { get; set; }

        [ValidateNever]
        public int DoktorRandevuId { get; set; }
        [ForeignKey("DoktorRandevuId")]

        [ValidateNever]
        public DoktorlarTablosu DoktorlarTablosu { get; set; }

        [Required]
        public string GunHafta { get; set; }

        [Required]
        public TimeSpan BaslamaSaati { get; set; }

        [Required]
        public TimeSpan BitisSaati { get; set; }


    }
}
