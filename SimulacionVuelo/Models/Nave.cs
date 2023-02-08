using System.ComponentModel.DataAnnotations.Schema;

namespace SimulacionVuelo.Models
{
    public class Nave
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string nombre { get; set; }

        public int longitud { get; set; }

        public int ancho { get; set; }

        public int peso { get; set; }

        public int MotorId { get; set; }

        public Motor Motor { get; set; }

    }
}
