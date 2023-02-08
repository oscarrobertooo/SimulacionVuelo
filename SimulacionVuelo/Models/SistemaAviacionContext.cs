using Microsoft.EntityFrameworkCore;
using SimulacionVuelo.Models;

namespace SimulacionVuelo.Models
{
    public class SistemaAviacionContext : DbContext
    {

        public DbSet<Piloto> pilotos {get; set;}

        public DbSet<Combustible> combustibles { get; set; }

        public DbSet<Motor> motores { get; set; }

        public DbSet<Nave> naves { get; set; }

        public DbSet<Planeta> planetas { get; set; }

        public DbSet<Vuelo> vuelos { get; set; }


        public SistemaAviacionContext(DbContextOptions<SistemaAviacionContext> options) : base(options)
        {

        }

        //método se ejecuta cuando se crea la BD 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
