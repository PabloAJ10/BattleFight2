using BattleFight.Models;
using BattleFight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleFight.Controllers
{
    public class EquipoController : Controller
    {

        private Service service;

        public EquipoController()

        {

            service = new Service();

        }


        // GET: EquipoController
        public ActionResult Index()
        {
            var model = service.mostrarEquipo();

            return View(model);
        }

        // POST: EquipoController/Index

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Index(string Categoria)

        {

            var model = new List<Equipo>();

            if (!string.IsNullOrEmpty(Categoria))

                model = service.filtroEquipo(Categoria);

            else model = service.mostrarEquipo();

            return View(model);

        }

        // GET:EquipoController/Details/5
        public ActionResult Details(int equipoid)
        {
            return View();
        }


        // GET: EquipoController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: EquipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipo equipo)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    service.agregarEquipo(equipo);
                    return RedirectToAction("Index");
                }
            }

            catch
            { }

            return View();
        }

        // GET: EquipoController/Edit/5
        public ActionResult Edit(int equipoid)
        {
            var equipoBuscado = service.buscarEquipo(equipoid);

            return View(equipoBuscado);
           
        }

        // POST: EquipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipo equipoActualizado)
        {
            try

            {
                service.actualizarEquipo(equipoActualizado);
                return RedirectToAction("Index");
            }

            catch (Exception ex)

            {

                ViewBag.Error = ex.Message;
                return View(equipoActualizado);

            }
        }

        
        
    }
}
