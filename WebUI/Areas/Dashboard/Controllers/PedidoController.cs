using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Utilities;
using WebUI.Entities;
using WebUI.Manager;
using WebUI.Areas.Dashboard.ViewModels;

namespace WebUI.Areas.Dashboard.Controllers
{
    public class PedidoController : AdminBaseController
    {
        public ActionResult Recibidos()
        {
            IEnumerable<Pedido> listaPedidos = PedidoManager.GetRecibidos(usuario.Id);
            return View(listaPedidos);
        }

        public ActionResult Enviados()
        {
            IEnumerable<Pedido> listaPedidos = PedidoManager.GetEnviados(usuario.Id);
            return View(listaPedidos);
        }

        [HttpPost]
        public ActionResult Pedido(int IdPedido)
        {
            Pedido pedido = PedidoManager.GetPedido(usuario.Id, IdPedido);
            if (pedido.Visto == "novisto")
            {
                PedidoManager.SetVisto(IdPedido);
            }

            PedidoViewModel pedidoVM = new PedidoViewModel()
            {
                IdPedido = pedido.IdPedido,
                Arbol = pedido.Arbol,
                Emisor = pedido.Emisor,
                Receptor = pedido.Receptor,
                Oferta = pedido.Oferta,
                Fecha = pedido.Fecha
            };

            string vistaParcial = "";
            if (usuario.Id == pedidoVM.Emisor.Id)
            {
                vistaParcial = "_Enviado";
            }
            else
            {
                switch (pedido.Estado)
                {
                    case "Pendiente": vistaParcial = "_Pendiente";break;
                    case "Aceptado": vistaParcial = "_Aceptado"; break;
                    case "Rechazado": vistaParcial = "_Rechazado"; break;
                    default: break;
                }
            }

            return PartialView("~/Areas/Dashboard/Views/Pedido/" + vistaParcial + ".cshtml", pedidoVM);
        }

        [HttpPost]
        public ActionResult Rechazar(int idPedido)
        {
            PedidoManager.Rechazar(idPedido);
            return Json(new WebUI.Models.AjaxResponseViewModel { Success = true, Message = "Pedido rechazado" }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Aceptar(int idPedido)
        {
            PedidoManager.Aceptar(idPedido);
            Pedido pedido = PedidoManager.GetPedido(idPedido);
            PedidoViewModel pedidoVM = new PedidoViewModel
            {
                IdPedido = pedido.IdPedido,
                Arbol = pedido.Arbol,
                Emisor = pedido.Emisor,
                Receptor = pedido.Receptor,
                Oferta = pedido.Oferta,
                Fecha = pedido.Fecha
            };
            return PartialView("~/Areas/Dashboard/Views/Pedido/_Aceptado.cshtml", pedidoVM);
        }

        [HttpPost]
        public void Eliminar(int idPedido, String visible)
        {
            PedidoManager.Eliminar(idPedido,visible);
        }
    }
}