using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FM_Grupo2.Models;

namespace FM_Grupo2.DAL
{
    public class FMInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FMContext>
    { }
}