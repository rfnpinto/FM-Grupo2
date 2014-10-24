using FM_Grupo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FM_Grupo2.ViewModels
{
    public class TemporadaIndexData
    {
        public IEnumerable<Temporada> Temporadas { get; set; }
        public IEnumerable<Equipa> Equipa { get; set; }
    }
}