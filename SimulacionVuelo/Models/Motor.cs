namespace SimulacionVuelo.Models
{
    public class Motor
    {
        public string Id { get; set; }

        public string nombre { get; set; }

        public float comburente { get; set; }

        public float capicidadCombustible { get; set; }

        public string CombustibleId { get; set; }

        public Combustible Combustible { get; set; }


    }
}
