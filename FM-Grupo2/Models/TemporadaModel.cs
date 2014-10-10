using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class TemporadaModel
    {

        public int ID { get; set; }

        [Required]
        public virtual CampeonatoModel Campeonato { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/yyyy+1}", ApplyFormatInEditMode = true)]
        public DateTime Ano { get; set; }
        
        [Required]
        public string Descricao { get; set; }
        

        public virtual ICollection<EquipaModel> Equipas { get; set; }
        
        public int NJornadas { get; set; }

    }
}