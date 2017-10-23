using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebUI.Entities;
using WebUI.Manager;
using WebUI.Utilities;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class BuscadorController : Controller
    {
        public ActionResult Buscar(BuscarViewModel model)
        {
            int? IdUsuario = null;
            if (Session[Constantes.KeyCurrentUser] != null)
            {
                Usuario usuario = (Usuario)Session[Constantes.KeyCurrentUser];
                IdUsuario = usuario.Id;
            }
            ViewBag.Variedad = model.Variedad;
            ViewBag.Titulo = "Resultados de búsqueda";
            List<Arbol> arbols = ArbolManager.GetArbolesByVariedad(model.Variedad, IdUsuario);
            //armar array de destinos
            String destinos = "";
            foreach (var arbol in arbols)
            {
                destinos += arbol.Latitud + ", " + arbol.Longitud + "|";
            }
            //pasarlo al manager
            JObject arrayDistancias = ArbolManager.CalcularDistancia(model.Posicion, destinos);
            //armar el viewmodel y agregar la ditancia
            List<ResultadosViewModel> arboles = new List<ResultadosViewModel>();
            for (int i = 0; i < arbols.Count; i++)
            {
                arboles.Add(
                    new ResultadosViewModel
                    {
                        Id = arbols[i].Id,
                        Variedad = arbols[i].Variedad,
                        Disponibilidad = arbols[i].Disponibilidad,
                        Latitud = arbols[i].Latitud,
                        Longitud = arbols[i].Longitud,
                        Direccion = arbols[i].Direccion,
                        Distancia = arrayDistancias["rows"][0]["elements"][i]["distance"]["text"].ToString()
                    }
                );
        }
            //reordeno la lista con linq segun distancia
            var result = (from s in arboles
                         select s).OrderBy(x => x.Distancia);
            return View("Resultados", result);
        }

        public ActionResult Detalle(int id)
        {
            ViewBag.Titulo = "Detalle";
            Arbol arbol = ArbolManager.GetArbol(id);
            String destino = arbol.Latitud + ", " + arbol.Longitud;
            JObject arrayDistancias = ArbolManager.CalcularDistancia("-34.9314, -57.9489", destino);
            String distancia = arrayDistancias["rows"][0]["elements"][0]["distance"]["text"].ToString();
            List<ResultadosViewModel> arboles = new List<ResultadosViewModel>
            {
                new ResultadosViewModel
                {
                    Id = arbol.Id,
                    Variedad = arbol.Variedad,
                    Disponibilidad = arbol.Disponibilidad,
                    Direccion = arbol.Direccion,
                    Distancia = distancia
                }
            };
            return View("Resultados", arboles);
        }
    }
}