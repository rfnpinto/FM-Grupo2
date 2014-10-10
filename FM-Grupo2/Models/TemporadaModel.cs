using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class TemporadaModel
    {

        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime Ano { get; set; }
        public string Descricao { get; set; }
        public int NEquipas { get; set; }
        public int NJornadas { get; set; }


     

    }
}