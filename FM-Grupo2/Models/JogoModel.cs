using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class Jogo
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
        public DateTime Data { get; set; }

        public string Resultado { get; set; }

        /**
         * Ligações com outros modelos;
         */
        public virtual ICollection<Equipa> Equipa { get; set; }
    }
    
}