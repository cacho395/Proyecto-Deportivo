using Microsoft.EntityFrameworkCore;
using Dominio;

namespace Persistencia 
{
    public class AppContext:DbContext
    {
        //Atribuos
        public DbSet<Municipio> Municipios {get;set;}
        public DbSet<Patrocinador> Patrocinadores {get;set;}
        public DbSet<Colegio> Colegios {get;set;}
        public DbSet<Torneo> Torneos {get;set;}
        public DbSet<Arbitro> Arbitros {get;set;}
        public DbSet<Equipo> Equipos {get;set;}
        public DbSet<Entrenador> Entrenadores {get;set;}
        public DbSet<UnidadDeportiva> UnidadDeportivas {get;set;}
        public DbSet<Escenario> Escenarios {get;set;}
        public DbSet<Deportista> Deportistas {get;set;}
        public DbSet<TorneoEquipo> TorneoEquipos {get;set;}

        // crear la conexion de la DB

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Eventos30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TorneoEquipo>().HasKey(x=>new {x.TorneoId,x.EquipoId});

            //Marcar un campo como unico
            modelBuilder.Entity<Torneo>().HasIndex(t => t.Nombre).IsUnique();
            modelBuilder.Entity<Colegio>().HasIndex(c =>c.Nit).IsUnique();
            modelBuilder.Entity<Entrenador>().HasIndex(e => e.Documento).IsUnique();
            modelBuilder.Entity<Equipo>().HasIndex(eq => eq.Nombre).IsUnique();
            modelBuilder.Entity<Patrocinador>().HasIndex(p => p.Documento).IsUnique();
            modelBuilder.Entity<Arbitro>().HasIndex(a => a.Documento).IsUnique();
        }
    }
}