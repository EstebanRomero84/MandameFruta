using System.Web.Mvc;
using System.Text;
using WebUI.Utilities;
using WebUI.Manager;
using WebUI.ViewModels;
using System.Collections.Generic;
using WebUI.Entities;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Arbol> arboles = ArbolManager.GetTodos();
            return View(arboles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(model.NombreUsuario) || string.IsNullOrEmpty(model.Pass) || UsuarioManager.Login(model.NombreUsuario, model.Pass) == null)
            {                   
                ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                return PartialView("_ErrorSummary",model);                
            }
            else
            {
            Session[Constantes.KeyCurrentUser] = UsuarioManager.GetByNombreUsuario(model.NombreUsuario);
                if (model.id != null)
                {
                    return Json(new { url = Url.Action("PedirTrueque", "Trueque", new { id = model.id , area = "Dashboard"}) });
                }
                return Json(new { url = Url.Action("Recibidos", "Pedido", new { area = "Dashboard" }) });
            }
        }

        public ActionResult MostrarModalLogin(int? id)
        {
            LoginViewModel model = new LoginViewModel();
            model.id = id;
            return PartialView("_ModalLogin", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Resetear(string email)
        {
            Usuario usuario = UsuarioManager.GetByEmail(email);
            if (usuario != null)
            {
                if (UsuarioManager.ResetearContraseña(usuario))
                {
                    TempData["Msg"] = "Se ha enviado un correo a su casilla con su nueva contraseña ...";
                    return RedirectToAction("Index");

                }
                else {
                    TempData["Msg"] = "No se encontró el mail..";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Msg"] = "Debe ingresar un email válido";
                return RedirectToAction("Index");
            }
        }

        public JsonResult BuscarEnListado(string query) {
            IEnumerable<string> arboles = ListaManager.GetArboles(query);
            return Json(arboles, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }

}