using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class JornadaModel
    {
        public int ID { get; set; }
        
        [Required]
        public int NumJornada { get; set; }

        [Required]
        public int TemporadaID { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        public virtual ICollection<JogoModel> Jogo { get; set; }
        
        public virtual TemporadaModel Temporada { get; set; }
    }
}