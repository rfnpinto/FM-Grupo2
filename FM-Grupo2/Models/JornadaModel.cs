using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class Jornada
    {
        /**
         * ID's;
         */
        public int JornadaID { get; set; }

        public int TemporadaID { get; set; }
        

        /**
         * Campos do Modelo; 
         */
        [Required]
        public int NumJornada { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        /**
         * Ligações aos outros modelos;
         */

        public virtual Temporada Temporada { get; set; }

        public virtual ICollection<Jogo> Jogo { get; set; }
    }
}