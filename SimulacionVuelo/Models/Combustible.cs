using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulacionVuelo.Models
{

 
    public class Combustible
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public  string  nombre { get; set; }

        public string estado { get; set; }


        public List<Motor> Motores { get; set; }


    }
}
