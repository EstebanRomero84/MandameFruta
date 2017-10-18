using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Utilities
{
    public class Constantes
    {
        #region Messagges
        public const string UIMessageUnauthorized = "Al parecer ha caducado su sesión. Será redireccionado al login..";
        public const string UIMessageMethodNotAllowed = "No tiene los permisos necesarios para el recurso que intenta acceder.";
        #endregion

        #region Key
        public const string KeyCurrentUser = "KeyCurrentUser";
        //public const string KeyCurrentUserNombre = "KeyCurrentUserNombre";
        //public const string KeyCurrentUserNombreUsuario = "KeyCurrentUserNombreUsuario";
        public const string KeyConnectionStringComIT = "MandameFruta";
        #endregion

        public static string Encriptar(string texto)
        {
            System.Security.Cryptography.SHA1 sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();

            byte[] inputBytes = (new System.Text.UnicodeEncoding()).GetBytes(texto);
            byte[] hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }

        public static string GenerarRandom()
        {
            string caracteresPermitidos = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            string random = "";
            Random rd = new Random();

            for (int i = 0; i < 5; i++)
            {
                random+= caracteresPermitidos[rd.Next(0, caracteresPermitidos.Length)];
            }

            return random;
        }
    }
}