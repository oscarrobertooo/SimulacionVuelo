using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulacionVuelo.Models;

namespace SimulacionVuelo.Controllers
{
    public class NavesController : Controller
    {

        private SistemaAviacionContext _context;

        public NavesController(SistemaAviacionContext context)
        {
            _context = context;
        }


        // GET: NavesController
        public ActionResult Index()
        {
            var conexion = _context.Database.GetDbConnection();
            IEnumerable<Nave> ListNaves = _context.naves.ToList();
            foreach (var nave in ListNaves)
            {

                var motor = _context.motores.Where(p => p.Id == nave.MotorId).SingleOrDefault();
                nave.Motor = motor;
            }

            return View(ListNaves);
        }

        // GET: NavesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Agregar()
        {

            var conexion = _context.Database.GetDbConnection();
            IEnumerable<String> ListMotores = _context.motores.Select(x => x.nombre).ToList(); ;
            ViewBag.MyList = ListMotores;
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Nave nave)

        {

            Console.WriteLine(nave.Motor.nombre);

            var motor = _context.motores.Where(p => p.nombre == nave.Motor.nombre).SingleOrDefault();
            nave.MotorId = motor.Id;
            nave.Motor = motor;
            _context.naves.Add(nave);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: NavesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NavesController/Create
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

        // GET: NavesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NavesController/Edit/5
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

        // GET: NavesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NavesController/Delete/5
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
