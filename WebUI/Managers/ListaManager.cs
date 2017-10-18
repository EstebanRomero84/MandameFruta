using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Manager
{
    public class ListaManager
    {
        public static List<string> Arboles = new List<string>{ "ananá", "arándano", "arándanorojo", "banana", "cereza", "ciruela", "coco", "damasco", "durazno", "frambuesa", "frutilla", "granada", "grosellanegra", "higo", "kiwi", "lima", "limón", "mandarina", "mango", "manzana", "maracuyá", "melón", "membrillo", "mora", "naranja", "palta", "pera", "pomelo", "sandía", "uva" };

        public static IEnumerable<string> GetArboles(string consulta)
        {
            IEnumerable<string> listaarboles =
                from arbol in Arboles
                where arbol.Contains(consulta)
                select arbol;
            return listaarboles;
        }
    }
}