using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class CampeonatoModel
    {
        /*
         * ID's
         */ 
        public int ID { get; set; }

        /*
         * Campos do Modelo
         */
        [Required(ErrorMessage = "O campo Nome Campeonato é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Nome do Campeonato não pode execeder os 50 caracteres")]
        [Display(Name = "Nome Campeonato")]
        public string Nome { get; set; }

        [Display(Name = "Logotipo")]
        public string LogotipoPath { get; set; }

        [Required(ErrorMessage="O campo Abragência é obrigatório.")]
        [Display(Name = "Abrangência")]
        public char Abrangencia { get; set; }

        [Required(ErrorMessage = "O campo Frequência é obrigatório.")]
        [Display(Name = "Frequência")]
        public char Frequencia { get; set; }

        [Required(ErrorMessage="o campo Nacionalidade é obrigatório.")]
        [Display(Name = "Nacionalidade")]
        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "O campo Entidade Organizadora é obrigatório.")]
        [Display(Name = "Entidade Organizadora")]
        public int EntidadeOrganizadora { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [StringLength(200, ErrorMessage = "A Descrição do Campeonato não pode execeder os 200 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Data de Fundação é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Fundação")]
        public DateTime DataFundacao { get; set; }

        /*
         * Ligações aos outros modelos
         */
        public virtual ICollection<TemporadaModel> Temporada { get; set; }
    }
}