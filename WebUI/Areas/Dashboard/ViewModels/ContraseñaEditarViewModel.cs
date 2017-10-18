using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.Areas.Dashboard.ViewModels
{
    public class ContraseñaEditarViewModel
    {
        [Required]
        [Display(Name = "Contraseña actual")]
        [DataType(DataType.Password)]
        public string AnteriorPass { get; set; }

        [Required]
        [Display(Name = "Contraseña nueva")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Required]
        [Display(Name = "Confirmar contraseña nueva")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Pass")]
        public string ConfirmarPass { get; set; }
    }
}