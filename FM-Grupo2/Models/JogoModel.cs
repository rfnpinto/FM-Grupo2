using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FM_Grupo2.Models
{
    public class JogoModel
    {

        public int ID { get; set; }

        public string EquipaVisitante { get; set; }

        public string EquipaVisitada { get; set; }

        public DateTime Data { get; set; }

        public DateTime Hora { get; set; }

        public string Resultado { get; set; }
    }
    
}