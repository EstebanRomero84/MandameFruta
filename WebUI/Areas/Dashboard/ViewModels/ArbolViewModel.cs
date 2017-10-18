using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.Entities;

namespace WebUI.Areas.Dashboard.ViewModels
{
    public class ArbolViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Variedad")]
        public EVariedad Variedad { get; set; }

        [Required]
        [Display(Name = "Disponibilidad")]
        public EDisponibilidad Disponibilidad { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public String Direccion { get; set; }

        [HiddenInput(DisplayValue = false)]
        public String Latitud { get; set; }

        [HiddenInput(DisplayValue = false)]
        public String Longitud { get; set; }
    }
}