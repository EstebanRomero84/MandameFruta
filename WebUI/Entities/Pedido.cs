using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Entities
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public Arbol Arbol { get; set; }
        public Usuario Emisor { get; set; }//Id del emisor
        public Usuario Receptor { get; set; }//Id del destinatario
        public List<Arbol> Oferta { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }//TODO: ver el tema de timestamp
        public string Visto { get; set; }
    }
}