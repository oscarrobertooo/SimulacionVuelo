using System.ComponentModel.DataAnnotations.Schema;

namespace SimulacionVuelo.Models
{
    public class Vuelo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DuracionSemanas { get; set; }
        public int NaveId { get; set; }
        public int PilotoId { get; set; }
        public int PlanetaId { get; set; }

        public Nave Nave { get; set; }
        public Piloto Piloto { get; set; }
        public Planeta Planeta { get; set; }
    }
}
