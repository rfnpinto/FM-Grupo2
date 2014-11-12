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

        [Required(ErrorMessage = "O campo Jornada é obrigatório.")]
        [Display(Name = "Jornada")]
        public int JornadaID { get; set; }

        /**
         * Campos do modelo;
         */
        [Required(ErrorMessage = "O campo Equipa Visitada é obrigatório.")]
        [Display(Name = "Equipa Visitada")]
        public int VisitadaEquipaID { get; set; }

        [Required(ErrorMessage = "O campo Equipa Visitante é obrigatório.")]
        [Display(Name = "Equipa Visitante")]
        public int VisitanteEquipaID { get; set; }

        [Required]
        [Display(Name = "Data do Jogo")]
        public DateTime Data { get; set; }

        public string Resultado { get; set; }

        /**
         * Ligações com outros modelos;
         */
        public virtual Equipa Equipa { get; set; }

        public virtual Jornada Jornada { get; set; }
    }
    
}