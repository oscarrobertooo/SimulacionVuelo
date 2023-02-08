using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulacionVuelo.Models;

namespace SimulacionVuelo.Controllers
{
    public class PlanetasController : Controller
    {

        private SistemaAviacionContext _context;

        public PlanetasController(SistemaAviacionContext context)
        {
            _context = context;
        }

        // GET: PlanetasController
        public ActionResult Index()
        {
            var conexion = _context.Database.GetDbConnection();
            IEnumerable<Planeta> ListPlanetas = _context.planetas.ToList();
            
            return View(ListPlanetas);
        }

        // GET: PlanetasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Agregar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Agregar(Planeta planeta)

        {


            planeta.longitud = Math.Round(planeta.longitud, 2);
            planeta.latitud = Math.Round(planeta.latitud, 2);
            planeta.altitud = Math.Round(planeta.altitud, 2);
            planeta.distaciaDeLaTierra = Math.Round(planeta.distaciaDeLaTierra, 2);




            _context.planetas.Add(planeta);
            _context.SaveChanges();

            return View("Index", _context.planetas);
        }



        // GET: PlanetasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanetasController/Create
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

        // GET: PlanetasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanetasController/Edit/5
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

        // GET: PlanetasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanetasController/Delete/5
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
