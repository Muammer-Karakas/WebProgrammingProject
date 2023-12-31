﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ValidateNever]
        public int KlinikId {  get; set; }
        [ForeignKey("KlinikId")]

        [ValidateNever]
        public KlinikTuru KlinikTuru { get; set; }

        [Required]
        public string GunHafta { get; set; }

        [Required]
        public TimeSpan BaslamaSaati { get; set; }

        [Required]
        public TimeSpan BitisSaati { get; set; }

        

    }
}
