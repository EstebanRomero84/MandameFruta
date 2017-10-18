using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebUI.Entities;

namespace WebUI.Areas.Dashboard.ViewModels
{
    public class ArbolCheckBoxModel
    {
        [Required]
        public int Id { get; set; }

        public string Variedad { get; set; }
    }

    public class FormularioPedidoViewModel
    {
        public int IdArbol { get; set; }//id del arbol a pedir

        [Display(Name = "Variedad")]
        public string Variedad { get; set; }//variedad del arbol a pedir

        [Display(Name = "Disponibilidad")]
        public string Disponibilidad { get; set; }//Disponibilidad del arbol a pedir

        public int Emisor { get; set; }//Id del emisor

        public int Receptor { get; set; }//Id del destinatario

        [Display(Name = "Oferta")]
        public string[] ArbolesSeleccionados { get; set; }

        public List<ArbolCheckBoxModel> Oferta { get; set; }//listado de los arboles del oferente
    }
}