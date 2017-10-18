using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Areas.Dashboard.ViewModels;
using WebUI.Utilities;
using WebUI.Entities;
using WebUI.Manager;

namespace WebUI.Areas.Dashboard.Controllers
{
    public class ArbolController : AdminBaseController
    {
        /// <summary>
        /// Devuelve una lista con los arboles que pertenecen al idUsuario pasado por parametro
        /// </summary>
        /// <returns></returns>
        public ActionResult Lista()
        {
            IEnumerable<Arbol> listaArboles = ArbolManager.GetArboles(usuario.Id);
            return View(listaArboles);
        }

        /// <summary>
        /// Devuelve vista detalle del idArbol pasado opr parametro
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Detalle(int Id)
        {
            //TODO: agregar validacion para verificar que el arbol sea del usuario en sesion
            Arbol Arbol = ArbolManager.GetArbol(Id);
            return View(Arbol);
        }
        public ActionResult Nuevo()
        {
            return View();
        }

        /// <summary>
        /// Agregar nuevo arbol. Recibe viewmodel, crea un arbol con los dtos del viewmodel y lo pasa al manager para que este lo agregue a BD
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(ArbolViewModel model)
        {
            if (ModelState.IsValid)
            {
                Arbol arbol = new Arbol
                {
                    IdUsuario = usuario.Id,
                    Variedad = model.Variedad,
                    Disponibilidad = model.Disponibilidad,
                    Direccion = model.Direccion,
                    Latitud = model.Latitud,
                    Longitud = model.Longitud
                };
                ArbolManager.Nuevo(arbol);
                TempData["Msg"] = "Su nuevo árbol fue añadido correctamente";
            }else
            {
                TempData["Msg"] = "Error al añadir árbol";
            }
            return RedirectToAction("Lista", "Arbol");
        }

        public ActionResult Editar(int id)
        {
            Arbol arbol = ArbolManager.GetArbol(id);
            ArbolViewModel model = new ArbolViewModel
            {
                Id = arbol.Id,
                Variedad = arbol.Variedad,
                Disponibilidad = arbol.Disponibilidad,
                Direccion = arbol.Direccion,
                Latitud = arbol.Latitud,
                Longitud = arbol.Longitud
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ArbolViewModel model)
        {
            if (ModelState.IsValid)
            {
                Arbol arbol = new Arbol
                {
                    Id = model.Id,
                    IdUsuario = usuario.Id,
                    Variedad = model.Variedad,
                    Disponibilidad = model.Disponibilidad,
                    Direccion = model.Direccion,
                    Latitud = model.Latitud,
                    Longitud = model.Longitud
                };
                ArbolManager.Editar(arbol);
                TempData["Msg"] = "Su árbol fue modificado correctamente";
            }
            else
            {
                TempData["Msg"] = "Error al añadir árbol";
            }
            return RedirectToAction("Lista", "Arbol");
        }

        public ActionResult Borrar(int id)
        {
            ArbolManager.Borrar(id);
            TempData["Msg"] = "El plato ha sido borrado correctamente.";
            return RedirectToAction("Lista", "Arbol");
        }
    }
}