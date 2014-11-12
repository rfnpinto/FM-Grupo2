using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FM_Grupo2.ViewModels
{
    public class AssignedEquipaData
    {
        public int EquipaID { get; set; }
        public string Nome { get; set; }
        public int CountryID { get; set; }
        public bool Assigned { get; set; }
    }
}