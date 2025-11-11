using BattleFight.Models;
using BattleFight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleFight.Controllers
{
    public class TorneoController : Controller
    {

        private Service service;

        public  TorneoController()
        {
            service = new Service();
        }
        // GET: TorneoController
        public ActionResult Index()
        {
            var model = service.mostrarTorneo();
            return View(model);
        }

        // GET: TorneoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TorneoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Torneo torneo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.agregarTorneo(torneo);
                    return RedirectToAction("Index");
                }
            }
            catch
            {}
            return View();
        }

        // GET: TorneoController/Edit/5
        public ActionResult Edit(int torneoid)
        {
            var torneoBuscado = service.buscarTorneo(torneoid);
            return View(torneoBuscado);
        }

        // POST: TorneoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Torneo torneoActualizado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.actualizarTorneo(torneoActualizado);
                    return RedirectToAction("Index");

                }
            }
            catch
            {}
            return View();
        }

        // GET: TorneoController/Delete/5
        public ActionResult Delete(int torneoid)
        {
            var torneoBuscado = service.buscarTorneo(torneoid);
            return View(torneoBuscado); 
        }

        // POST: TorneoController/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int torneoid)
        {
            try
            {
                var torneoBuscado = service.buscarTorneo(torneoid);
                service.eliminarTorneo(torneoBuscado); 
                return RedirectToAction("Index"); 
            }
            catch (Exception)
            {
                return View();
            }
        }

        
        // GET: TorneoController/AsignarEquipos/5
        public ActionResult AsignarEquipos(int torneoid)
        {
            var torneo = service.buscarTorneo(torneoid);
            var equipos = service.mostrarEquiposPorCategoria(torneo.CategoriaEnfrentar);
            ViewBag.Torneo = torneo;
            return View(equipos); 
        }

        // POST: TorneoController/DeterminarGanador
        [HttpPost]
        public ActionResult DeterminarGanador(int torneoid, List<int> idsEquipos)
        {
            try
            {
                var equiposSeleccionados = service.obtenerEquiposPorIds(idsEquipos);
                var ganador = service.determinarGanador(equiposSeleccionados);

                // Actualizar el torneo con el ganador
                var torneo = service.buscarTorneo(torneoid);
                torneo.Ganador = ganador.NombreEquipo;
                service.actualizarTorneo(torneo);

                ViewBag.Ganador = ganador;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("AsignarEquipos", new { torneoid });
            }
        }
    }
}
