using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class JogoModel
    {
        /**
         * ID's;
         */
        public int ID { get; set; }

        /**
         * Campos do modelo;
         */
        public int EquipaVisitada { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        public string Resultado { get; set; }

        /**
         * Ligações com outros modelos;
         */
        public virtual ICollection<EquipaModel> Equipa { get; set; }
    }
    
}