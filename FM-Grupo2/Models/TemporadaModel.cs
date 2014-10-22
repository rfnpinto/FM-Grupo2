using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class TemporadaModel
    {

        /**
         * ID's;
         */
        public int TemporadaID { get; set; }

        public int CampeonatoID { get; set; }
        
        /**
         * Campos do Modelo;
         */
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public DateTime Ano { get; set; }
        
        [Required]
        public string Descricao { get; set; }
        
        public int NJornadas { get; set; }

        /**
         * Ligações aos outros modelos;
         */
        public virtual CampeonatoModel Campeonato { get; set; }
        public virtual ICollection<EquipaModel> Equipas { get; set; }
        
    }
}