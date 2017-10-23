using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.ViewModels
{
    public class BuscarViewModel
    {
        [Required]
        public String Variedad { get; set; }

        [HiddenInput(DisplayValue = false)]
        public String Posicion { get; set; }
    }
}