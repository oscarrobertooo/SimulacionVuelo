using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using Microsoft.EntityFrameworkCore;
using SimulacionVuelo.Hubs;
using SimulacionVuelo.Models;
using System.Diagnostics;

namespace SimulacionVuelo.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SistemaAviacionContext _context;
        private IHubContext<ChatHub> _hubContext;

        public HomeController(ILogger<HomeController> logger, SistemaAviacionContext context, IHubContext<ChatHub> hubContext)
        {
            _logger = logger;
            _context = context;
            _hubContext = hubContext;
        }




        public IActionResult Index()
        {




            var conexion = _context.Database.GetDbConnection();
            List<Piloto> ListPiloto = _context.pilotos.ToList();
            List<Planeta> ListPlaneta = _context.planetas.ToList();
            List<Nave> ListNave = _context.naves.ToList();

            var simulacion = new Simulacion();

            simulacion.pilotos = ListPiloto;
            simulacion.planetas = ListPlaneta;
            simulacion.naves = ListNave;




            return View(simulacion);
        }





        [HttpPost]
        public async Task<IActionResult> Index(string IdPiloto, string IdPlaneta, string IdNave)
        {



            //Aquí sigue recuperar los valores de la Simulación y empezar a programar las funciones del Core porque el bóton ya fue presionado
            var pilotoVuelo = _context.pilotos.SingleOrDefault(piloto => piloto.Id == int.Parse(IdPiloto));
            var planetaDestino = _context.planetas.SingleOrDefault(planeta => planeta.Id == int.Parse(IdPlaneta));
            var naveVuelo = _context.naves.SingleOrDefault(nave => nave.Id == int.Parse(IdNave));
            var motorVuelo = _context.motores.SingleOrDefault(motor => motor.Id == naveVuelo.MotorId);


            //El core es el diagrama de flujo, hay que seguilo y agregar cosas que falten
            double tiempoEstimadoLLegada = 0;
            double climaExterior = 34;

            string horaTierra = "";
            double tiempoEnVuelo = 0;
            double velocidadNave = 1;


            double distanciaRecorrida = 1;
            double gravedad = 9.18; //m/s
            double velocidadCombustion;
            double empujeVuelo;
            double velocidadPropulsion;
            double vInicial = 0;



            double pesoTotalDeLaNave = motorVuelo.comburente + motorVuelo.capicidadCombustible + naveVuelo.peso + pilotoVuelo.peso;
            double masaFinalNave = pesoTotalDeLaNave;


            int z = 0;
            int i = 0;
            double posicionNave = 100;

            //Vemos si el cohete ya llego
            while (distanciaRecorrida < planetaDestino.distaciaDeLaTierra)
            {

               
                z++;
                Console.WriteLine("vueltassss");
                if (climaExterior >= -200)
                {
                    climaExterior = climaExterior - 1;
                }

                velocidadCombustion = 0.01 * (climaExterior * climaExterior);
                motorVuelo.comburente = motorVuelo.comburente - velocidadCombustion;
                motorVuelo.capicidadCombustible = motorVuelo.capicidadCombustible - velocidadCombustion;
                masaFinalNave = motorVuelo.comburente + motorVuelo.capicidadCombustible + naveVuelo.peso + pilotoVuelo.peso;

                empujeVuelo = (motorVuelo.comburente + motorVuelo.capicidadCombustible) * velocidadCombustion * motorVuelo.eficienciaCombustible;
                velocidadPropulsion = Math.Sqrt(2 * empujeVuelo);
                tiempoEstimadoLLegada = planetaDestino.distaciaDeLaTierra / Math.Abs(velocidadNave);
                double a = (pesoTotalDeLaNave / masaFinalNave);
                velocidadNave = vInicial - gravedad * tiempoEnVuelo + velocidadPropulsion * Math.Log(a, 2);


                vInicial = Math.Abs(velocidadNave);
                tiempoEnVuelo = tiempoEnVuelo + 1;
                distanciaRecorrida = distanciaRecorrida + Math.Abs(velocidadNave);

                horaTierra = DateTime.Now.ToString("HH:mm:ss");




                //Otra de las tareas esenciales es como voy a actualizar los valores del cuadro de la vista y hacer que el avión se eleve.
                //El avión lo podría elevar moviendole a la clase de bootstrap que hace referencia a la imagen. 
                pararPrograma();
                pararPrograma();
                pararPrograma();
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", (int)tiempoEstimadoLLegada, (int)climaExterior, (int)motorVuelo.comburente, (int)motorVuelo.capicidadCombustible, horaTierra, (int)tiempoEnVuelo, Math.Abs((int)velocidadNave), posicionNave);
                posicionNave = posicionNave - 5;
                pararPrograma();
                pararPrograma();
                pararPrograma();




            }




            //Por último sería bueno mostrar un Modal una vez que el programa fue terminado.
            return RedirectToAction("Index");

        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void pararPrograma(){

                int i = 0;
                while (i < 1000000)
                {
                    i++;
                }
                i = 0;
                while (i < 1000000)
                {
                    i++;
                }
                i = 0;
                while (i < 1000000)
                {
                    i++;
                }
                i = 0;
                while (i < 1000000)
                {
                    i++;
                }
                i = 0;
                while (i < 1000000)
                {
                    i++;

                }
                i = 0;
                while (i < 1000000)
                {
                    i++;

                }
                i = 0;
                while (i < 1000000)
                {
                    i++;

                }
                i = 0;
                while (i < 1000000)
                {
                    i++;

                }
                i = 0;
                while (i < 1000000)
                {
                    i++;

                }
                i = 0;
                while (i < 1000000)
                {
                    i++;

                }
                i = 0;
                while (i < 1000000)
                {
                    i++;

                }


        }


        public void moverAvion() { 
        
        
        }


       
    }
}