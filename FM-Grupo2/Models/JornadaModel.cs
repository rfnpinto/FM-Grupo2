using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class JornadaModel
    {
        public int ID { get; set; }
        
        //IDTemporada
        public int NJornada { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }
    }
}