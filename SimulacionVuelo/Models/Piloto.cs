using System.ComponentModel.DataAnnotations.Schema;

namespace SimulacionVuelo.Models
{
    public class Piloto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string nombre { get; set; }

        public double peso { get; set; }

        public double altura { get; set; }


    }
}
