using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.ViewModels
{
    public class LoginViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int? id { get; set; }

        [Required]
        [Display(Name ="Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }
    }
}