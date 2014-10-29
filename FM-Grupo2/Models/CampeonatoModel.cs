using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class Campeonato
    {
        /*
         * ID's
         */ 
        public int CampeonatoID { get; set; }

        /*
         * Campos do Modelo
         */
        [Required(ErrorMessage = "O campo Nome Campeonato é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Nome do Campeonato não pode execeder os 50 caracteres")]
        [Display(Name = "Nome Campeonato")]
        public string Nome { get; set; }

        [Display(Name = "Logotipo")]
        public string LogotipoPath { get; set; }

        /*
         * ID's
         */

        [Required(ErrorMessage = "O campo Frequência é obrigatório.")]
        [Display(Name = "Frequência")]
        public int FrequencyID { get; set; }

        [Required(ErrorMessage="O campo Abragência é obrigatório.")]
        [Display(Name = "Abrangência")]
        public int ScopeID { get; set; }

        [Display(Name = "País de Origem")]
        public int? CountryID { get; set; }

        /*
         * Campos do Modelo
         */
        [Required(ErrorMessage = "O campo Entidade Organizadora é obrigatório.")]
        [Display(Name = "Entidade Organizadora")]
        public string EntidadeOrganizadora { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [StringLength(200, ErrorMessage = "A Descrição do Campeonato não pode execeder os 200 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Data de Fundação é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Fundação")]
        public DateTime DataFundacao { get; set; }

        /*
         * Ligações aos outros modelos
         */
        public virtual ICollection<Temporada> Temporada { get; set; }

        public virtual FrequencyModel Frequency { get; set; }
        public virtual ScopeModel Scope { get; set; }
        public virtual CountryModel Country { get; set; }
    }
}