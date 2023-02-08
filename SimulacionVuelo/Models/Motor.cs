using System.ComponentModel.DataAnnotations.Schema;

namespace SimulacionVuelo.Models
{
    public class Motor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string nombre { get; set; }

        public double comburente { get; set; }

        public double capicidadCombustible { get; set; }

        public double eficienciaCombustible { get; set; }

        public double oxigenoPorSegundo { get; set; }

        public double combustiblePorSegundo { get; set; }

        public int CombustibleId { get; set; }

        public Combustible Combustible { get; set; }


    }
}
