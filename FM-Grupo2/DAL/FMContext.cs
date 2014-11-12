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
        public FMContext() : base("FM_Context")
        {
        }

        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<Equipa> Equipas { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<FrequencyModel> Frequency { get; set; }
        public DbSet<ScopeModel> Scope { get; set; }
        public DbSet<CountryModel> Country { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Temporada>()
             .HasMany(c => c.Equipas).WithMany(i => i.Temporadas)
             .Map(t => t.MapLeftKey("TemporadaID")
                 .MapRightKey("EquipaID")
                 .ToTable("TemporadaEquipa"));
        }
    }
}