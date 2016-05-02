using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTemaPs.Models
{
    public class Spectacol
    {
        [Key]
        [Display(Name = "Titlul spectacolului")]
        public string SpectacolId { get; set; }

        [Required]
        [Display(Name = "Distributia")]
        public string distributia { get; set; }

        [Required]
        [Display(Name = "Regia")]
        public string regia { get; set; }

        [Required]
        [Display(Name = "Data Premierei"), DataType(DataType.Date)]
        public DateTime datapremierei { get; set; }

        [Required]
        [Display(Name = "Numar bilete")]
        public int numarBilete { get; set; }
    }
}