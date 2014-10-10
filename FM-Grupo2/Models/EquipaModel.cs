using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class EquipaModel
    {
        public int ID { get; set; }

        public string Logotipo { get; set; }

        public string NomeClube { get; set; }

        public DateTime DataFundacao { get; set; }

        public int NJogadores { get; set; }

        public string Localizacao { get; set; }
    }
}