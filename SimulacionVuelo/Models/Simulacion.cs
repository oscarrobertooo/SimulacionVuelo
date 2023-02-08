namespace SimulacionVuelo.Models
{
    public class Simulacion
    {
        public List<Piloto>? pilotos { get; set; }

        public List<Planeta>? planetas { get; set; }

        public List<Nave>? naves { get; set; }


        public int? IdPlaneta { get; set; }

        public int? IdPiloto { get; set; }

        public int? IdNave { get; set; }


        public Simulacion()
        {
            this.pilotos = null;
            this.planetas = null;
            this.naves = null;


        }


    }
}
