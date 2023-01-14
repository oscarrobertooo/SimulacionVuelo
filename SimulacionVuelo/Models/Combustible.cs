using Microsoft.EntityFrameworkCore;

namespace SimulacionVuelo.Models
{

    [Index(nameof(nombre), IsUnique = true)]
    public class Combustible
    {
        public string Id { get; set; }

        public  string  nombre { get; set; }

        public string estado { get; set; }


        public List<Motor> Motores { get; set; }


    }
}
