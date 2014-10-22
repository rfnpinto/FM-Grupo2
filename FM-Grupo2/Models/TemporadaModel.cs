using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class Temporada
    {

        /**
         * ID's;
         */
        public int TemporadaID { get; set; }

        [Display(Name = "Campeonato")]
        public int CampeonatoID { get; set; }
        
        /**
         * Campos do Modelo;
         */
        [Required(ErrorMessage = "O campo Nome Temporada é obrigatório.")]
        [Display(Name = "Nome Temporada")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo Ano Temporada é obrigatório.")]
        [Display(Name = "Ano Temporada")]
        public DateTime Ano { get; set; }
        
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage="O campo Número Jornadas é obrigatório.")]
        [Display(Name = "Número Jornadas")]
        public int NJornadas { get; set; }

        /**
         * Ligações aos outros modelos;
         */
        public virtual Campeonato Campeonato { get; set; }
        public virtual ICollection<Equipa> Equipas { get; set; }
        
    }
}