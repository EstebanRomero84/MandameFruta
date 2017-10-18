using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Manager;
using WebUI.ViewModels;
using WebUI.Entities;

namespace WebUI.Controllers
{
    public class AltaUsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CuentaNuevaViewModel model)
        {
            Boolean existeError = false;
            if (!UsuarioManager.EmailUnico(model.Email))
            {
                ModelState.AddModelError("Email", "El email ya fue utilizado.");
                existeError = true;
            }
            if (!UsuarioManager.NombreUsuarioUnico(model.NombreUsuario))
            {
                existeError = true;
                ModelState.AddModelError("NombreUsuario", "El nombre de usuario ya existe.");
            }
            if (existeError)
            {
                return View(model);
            }
            Usuario usuario = new Usuario
            {
                       Nombre = model.Nombre,
                NombreUsuario = model.NombreUsuario,
                        Email = model.Email,
                         Pass = model.Pass
            };

            UsuarioManager.Nuevo(usuario);
            TempData["Msg"] = "Su árbol fue modificado correctamente";
            return View("CuentaCreada",usuario);
        }
    }
}
//TODO: modificar columnas en BD para que nombreusuario y mail sean únicos