using System;
using System.Web.Mvc;
using WebUI.Areas.Dashboard.ViewModels;
using WebUI.Utilities;
using WebUI.Entities;
using WebUI.Manager;
using System.Collections.Generic;

namespace WebUI.Areas.Dashboard.Controllers
{
    public class UsuarioController : AdminBaseController
    {
        // GET: Usuario
        public ActionResult Detalle()
        {
            return View(usuario);
        }

        public ActionResult Editar()
        {
            UsuarioEditarViewModel model = new UsuarioEditarViewModel
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                NombreUsuario = usuario.NombreUsuario,
                Email = usuario.Email
            };            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(UsuarioEditarViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    NombreUsuario = model.NombreUsuario,
                    Email = model.Email
                };

                UsuarioManager.Editar(usuario);
                Session[Constantes.KeyCurrentUser] = usuario;
                TempData["Msg"] = "Los cambios fueron realizados correctamente";
            }
            else
            {
                TempData["Msg"] = "Error al realizar cambios";
            }

            return RedirectToAction("Detalle", "Usuario");
        }

        public ActionResult EditarContraseña()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarContraseña(ContraseñaEditarViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuarioConPassNueva = new Usuario
                {
                    Id = usuario.Id,
                    Pass = model.Pass//pas nueva
                };
                Usuario usuarioConPassAnterior = new Usuario
                {
                    Id = usuario.Id,
                    Pass = model.AnteriorPass
                };

                //paso una lista con 2 objetos usuario, en uno guardo la nueva pass y en otra que ingrsó como anterior
                List<Usuario> usuarios = new List<Usuario>
                {
                    usuarioConPassAnterior,
                    usuarioConPassNueva
                };

                UsuarioManager.EditarContraseña(usuarios);
                Session[Constantes.KeyCurrentUser] = usuario;
                TempData["Msg"] = "Los cambios fueron realizados correctamente";
                return RedirectToAction("Detalle", "Usuario");
            }

            TempData["Msg"] = "Error al realizar los cambios.";
            return RedirectToAction("Detalle", "Usuario");
        }

        //TODO: hacer action para crear nuevo usuario
    }
}