using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
    }


}