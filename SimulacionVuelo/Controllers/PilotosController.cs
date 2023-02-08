using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SimulacionVuelo.Models;

namespace SimulacionVuelo.Controllers
{
    public class PilotosController : Controller
    {

        private SistemaAviacionContext _context;

        public PilotosController(SistemaAviacionContext context)
        {
            _context = context;
        }


        // GET: PilotosController
        public ActionResult Index()
        {
            var conexion = _context.Database.GetDbConnection();
            IEnumerable<Piloto> ListPiloto = _context.pilotos.ToList();
            foreach (var pilot in ListPiloto) { 
                pilot.peso = Math.Round(pilot.peso, 2);
                pilot.altura = Math.Round(pilot.altura, 2);
            }
            return View(ListPiloto);
        }

        // GET: PilotosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PilotosController/Create
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Piloto piloto)

        {

          
            piloto.peso = Math.Round(piloto.peso, 2);
            piloto.altura = Math.Round(piloto.altura, 2);
            

            _context.pilotos.Add(piloto);
            _context.SaveChanges();

            return View("Index", _context.pilotos);
        }

        // POST: PilotosController/Create
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

        // GET: PilotosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PilotosController/Edit/5
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

        // GET: PilotosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PilotosController/Delete/5
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
