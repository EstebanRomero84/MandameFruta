using System.Web.Mvc;
using System.Collections.Generic;
using WebUI.Areas.Dashboard.ViewModels;
using WebUI.Manager;
using System.Linq;
using WebUI.Entities;
using System;

namespace WebUI.Areas.Dashboard.Controllers
{
    public class TruequeController : AdminBaseController
    {
        // GET: Dashboard/Trueque
        public ActionResult PedirTrueque(int id)
        {
            Arbol arbolBD = ArbolManager.GetArbol(id);
            if (arbolBD.IdUsuario == usuario.Id)
            {
                TempData["Msg"] = "No puedes realizar un pedido de trueque sobre tus propios árboles";
                return RedirectToAction("Buscar", "Buscador",new { area = "" , variedad = arbolBD.Variedad });
            }
            List<ArbolCheckBoxModel> arbolesdisponibles = new List<ArbolCheckBoxModel>();
            var arboles = ArbolManager.GetArboles(usuario.Id);
            foreach (Arbol arbol in arboles)
            {
                arbolesdisponibles.Add(new ArbolCheckBoxModel{ Id = arbol.Id, Variedad = arbol.Variedad.ToString()});
            }
            FormularioPedidoViewModel model = new FormularioPedidoViewModel {
                Variedad = arbolBD.Variedad.ToString(),//arbol por el que se pide trueque
                Disponibilidad = arbolBD.Disponibilidad.ToString(),//arbol por el que se pide trueque
                IdArbol = arbolBD.Id,// id del arbol por el que se pide trueque
                Emisor = usuario.Id,
                Oferta = arbolesdisponibles,//listado de los arboles que posee el interesado
                Receptor = UsuarioManager.Get(arbolBD.IdUsuario).Id//dueño del arbol
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult FormularioPedido(FormularioPedidoViewModel model)
        {
            Arbol arbol = ArbolManager.GetArbol(model.IdArbol);
            if (ModelState.IsValid)
            {
                List<Arbol> arbolesOfrecidos = new List<Arbol>();
                foreach (var item in model.ArbolesSeleccionados)
                {
                    arbolesOfrecidos.Add(ArbolManager.GetArbol(Int32.Parse(item)));
                }
                Pedido pedido = new Pedido {
                    Arbol = arbol,
                    Emisor = UsuarioManager.Get(model.Emisor),
                    Receptor = UsuarioManager.Get(model.Receptor),
                    Oferta = arbolesOfrecidos
                };
                PedidoManager.Nuevo(pedido);
                TempData["Msg"] = "El pedido fue realizado correctamente";
                return RedirectToAction("Enviados", "Pedido");
            }
            else
            {
                TempData["Msg"] = "No se pudo realizar el pedido";
                return RedirectToAction("PedirTrueque", "Trueque",  new {id = arbol.Id });
            }
        }
    }
}