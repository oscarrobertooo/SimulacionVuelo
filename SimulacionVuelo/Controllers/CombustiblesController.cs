using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulacionVuelo.Models;

namespace SimulacionVuelo.Controllers
{
    public class CombustiblesController : Controller
    {

        private SistemaAviacionContext _context;

        public CombustiblesController(SistemaAviacionContext context)
        {
            _context = context;
        }


        // GET: CombustiblesController
        public ActionResult Index()
        {

            var conexion = _context.Database.GetDbConnection();
            IEnumerable<Combustible> ListCombustible = _context.combustibles;
            return View(ListCombustible);
        }

        // GET: CombustiblesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Combustible combustible)

        {

            combustible.Id = Guid.NewGuid().ToString();
            _context.combustibles.Add(combustible);
            _context.SaveChanges();

            return View("Index", _context.combustibles);
        }

        // GET: CombustiblesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CombustiblesController/Create
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

        // GET: CombustiblesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CombustiblesController/Edit/5
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

        // GET: CombustiblesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CombustiblesController/Delete/5
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
