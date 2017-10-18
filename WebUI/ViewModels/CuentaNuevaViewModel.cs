using System.ComponentModel.DataAnnotations;


namespace WebUI.ViewModels
{
    public class CuentaNuevaViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Required]
        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("Pass")]
        public string ConfirmarPass { get; set; }
    }
}