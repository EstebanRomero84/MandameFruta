using System;
using System.Collections.Generic;
using WebUI.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace WebUI.Areas.Dashboard.ViewModels
{
    public class PedidoViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int IdPedido { get; set; }

        [Display(Name = "Variedad")]
        public Arbol Arbol { get; set; }

        [Display(Name = "De")]
        public Usuario Emisor { get; set; }//Id del emisor

        [Display(Name = "A")]
        public Usuario Receptor { get; set; }//Id del destinatario

        [Display(Name = "Oferta")]
        public List<Arbol> Oferta { get; set; }

        public string Estado { get; set; }

        public DateTime Fecha { get; set; }//TODO: ver el tema de timestamp

        public string Visto { get; set; }
    }
}