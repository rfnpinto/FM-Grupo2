using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class JogoModel
    {

        public int ID { get; set; }

        [Required]
        public string EquipaVisitante { get; set; }

        [Required]
        public string EquipaVisitada { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required]
        public DateTime Hora { get; set; }

        [Required]
        public string Resultado { get; set; }
    }
    
}