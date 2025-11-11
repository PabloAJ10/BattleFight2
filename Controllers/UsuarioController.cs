using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BattleFight.Models;
using BattleFight.Services;

namespace BattleFight.Controllers
{
    public class UsuarioController : Controller
    {
        private Service service;

        public UsuarioController()
        {
            this.service = new Service();
        }

        public ActionResult Acerca()
        {
            return View();
        }
        // GET: UsuarioController
        public ActionResult Index()
        {
            var model = service.mostrarUsuarios();
            return View(model);
        }
        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }
        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string user, string pass)
        {
            try
            {
                var UsuarioLogueado = service.ValidarInicioSesion(user, pass);
                HttpContext.Session.SetString("NombreUsuario", UsuarioLogueado.Nombre);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
                
            }
            
        }

      
        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
            try
            {
                // Validar contraseñas
                service.ValidarContrasenas(usuario);
                service.agregarUsuario(usuario);
                return RedirectToAction(nameof(Login)); 
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;  
                return View(usuario);

            }
        }
            

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            var usuarioBuscado = service.buscarUsuario(id);
            return View(usuarioBuscado);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuarioActualizado)
        {
            try
            {
                // Validar contraseñas
                service.ValidarContrasenas(usuarioActualizado);
                service.actualizarUsuario(usuarioActualizado);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(usuarioActualizado);

            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            
                var usuarioBuscado = service.buscarUsuario(id);
            
            return View(usuarioBuscado);
        }

   
        // POST: TorneoController/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var usuarioBuscado = service.buscarUsuario(id);
                service.eliminarUsuario(usuarioBuscado);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
