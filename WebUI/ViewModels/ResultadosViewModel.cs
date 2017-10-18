using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.Entities;

namespace WebUI.ViewModels
{
    public class ResultadosViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Variedad")]
        public EVariedad Variedad { get; set; }

        [Display(Name = "Disponibilidad")]
        public EDisponibilidad Disponibilidad { get; set; }

        [Display(Name = "Dirección")]
        public String Direccion { get; set; }

        [Display(Name = "Distancia")]
        public String Distancia { get; set; }

        [HiddenInput(DisplayValue = false)]
        public String Latitud { get; set; }

        [HiddenInput(DisplayValue = false)]
        public String Longitud { get; set; }
    }
}