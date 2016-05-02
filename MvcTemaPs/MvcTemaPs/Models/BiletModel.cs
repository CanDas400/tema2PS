using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemaPs.Models
{
    public class Bilet
    {
        [Key]
        public int BiletId { get; set; }

        [Required]
        [Display(Name = "Nume spectacol")]
        public string titlul { get; set; }


        [Required]
        [Display(Name = "Numar rand")]
        public int rand { get; set; }

        [Required]
        [Display(Name = "Numar coloana")]
        public int numar { get; set; }

        
    }
 }

