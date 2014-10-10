using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class EquipaModel
    {
        public int ID { get; set; }

        public string Logotipo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O Nome da Equipa não pode execeder os 50 caracteres")]
        public string NomeEquipa { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFundacao { get; set; }

        public string Localizacao { get; set; }
    }
}