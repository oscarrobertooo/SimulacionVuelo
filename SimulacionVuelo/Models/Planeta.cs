using System.ComponentModel.DataAnnotations.Schema;

namespace SimulacionVuelo.Models
{
    public class Planeta
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string nombre { get; set; }

        public string clima { get; set; }

        public double longitud { get; set; }

        public double latitud { get; set; }

        public double altitud { get; set;}

        public double distaciaDeLaTierra { get; set; }

        


    }
}
