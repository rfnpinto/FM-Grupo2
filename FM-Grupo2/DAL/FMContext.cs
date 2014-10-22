using FM_Grupo2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FM_Grupo2.DAL
{
    public class FMContext: DbContext
    {
        public FMContext() : base("FMContext")
        {
        }

        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<Equipa> Equipas { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<Jogo> Jogos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}