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
        public int EquipaID { get; set; }

        /**
         * Campos do Modelo;
         */
        [Required]
        [StringLength(50, ErrorMessage = "O Nome da Equipa não pode execeder os 50 caracteres")]
        public string NomeEquipa { get; set; }

        public string Logotipo { get; set; }

        public string Clube { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFundacao { get; set; }

        public string Localizacao { get; set; }
    }
}