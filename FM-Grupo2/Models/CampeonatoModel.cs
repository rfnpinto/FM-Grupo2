using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class CampeonatoModel
    {
        public int ID;

        [Required]
        [StringLength(50, ErrorMessage = "O Nome do Campeonato não pode execeder os 50 caracteres")]
        public string Nome;
        
        public string LogotipoPath;
        
        [Required]
        public char Abranjencia;

        [Required]
        public char Frequancia;

        [Required]
        public string Nacionalidade;

        [Required]
        public int EntidadeOrganizadora;

        [Required]
        [StringLength(200, ErrorMessage = "A Descrição do Campeonato não pode execeder os 200 caracteres")]
        public string Descricao;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFundacao;

        public virtual ICollection<TemporadaModel> Temporada { get; set; }
    }
}