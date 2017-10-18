using System.ComponentModel.DataAnnotations;
using System;

namespace WebUI.Entities
{
    public class Mensaje
    {
        public int IDMensaje { get; set; }
        [Display(Name = "De")]
        public int From { get; set; }
        public int To { get; set; }
        [Display(Name = "Mensaje")]
        public string Texto { get; set; }
        public bool Visto { get; set; }
        //TODO: agregar timestamp
        public DateTime Fecha;

    }
}