using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class EquipaModel
    {
        /**
         * ID's:
         */
        public int ID { get; set; }

        /**
         * Campos do Modelo;
         */
        [Required(ErrorMessage = "O campo Nome Equipa é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Nome da Equipa não pode execeder os 50 caracteres")]
        [Display(Name = "Nome Equipa")]
        public string NomeEquipa { get; set; }

        [Display(Name = "Logótipo")]
        public string Logotipo { get; set; }

        [Display(Name = "Clube")]
        public string Clube { get; set; }

        [Display(Name = "Localização")]
        public string Localizacao { get; set; }
    }
}