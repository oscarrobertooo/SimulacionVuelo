using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulacionVuelo.Models;

namespace SimulacionVuelo.Controllers
{
    public class MotoresController : Controller
    {

        private SistemaAviacionContext _context;

        public MotoresController(SistemaAviacionContext context)
        {
            _context = context;
        }

        // GET: MotoresController
        public ActionResult Index()
        {

           
        
            var conexion = _context.Database.GetDbConnection();
            IEnumerable<Motor> ListMotor = _context.motores.ToList();


            foreach (var motor in ListMotor) {
              
                var combustible = _context.combustibles.Where(p => p.Id ==  motor.CombustibleId).SingleOrDefault();
                motor.Combustible = combustible;
            }
            return View(ListMotor);
          
        }

        // GET: MotoresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Agregar()
        {

            var conexion = _context.Database.GetDbConnection();
            IEnumerable<String> ListCombustible = _context.combustibles.Select(x => x.nombre).ToList(); ;
            ViewBag.MyList = ListCombustible;
            return View();
        } 

        [HttpPost]
        public ActionResult Agregar(Motor motor)

        {

            //motor.Id = Guid.NewGuid().ToString();
            motor.combustiblePorSegundo = Math.Round(motor.combustiblePorSegundo, 2);
            motor.oxigenoPorSegundo  = Math.Round(motor.oxigenoPorSegundo, 2);
            motor.eficienciaCombustible = Math.Round(motor.eficienciaCombustible, 2);
            var combustible = _context.combustibles.Where(p => p.nombre == motor.Combustible.nombre).SingleOrDefault();
            motor.CombustibleId = combustible.Id;
            motor.Combustible = combustible;
            _context.motores.Add(motor);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: MotoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MotoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MotoresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MotoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MotoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MotoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
