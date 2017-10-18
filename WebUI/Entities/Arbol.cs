using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Entities
{
    public enum EVariedad
    {
        ananá, arándano, arándanorojo, banana, cereza, ciruela, coco, damasco , durazno, frambuesa, frutilla, granada, grosellanegra, higo, kiwi, lima, limón, mandarina, mango, manzana, maracuyá, melón, membrillo, mora, naranja, palta, pera, pomelo, sandía, uva
    }

    public enum EDisponibilidad
    {
        nula, baja, media, alta
    }
    public class Arbol
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public EVariedad Variedad { get; set; }//pasar los enum a BD
        public EDisponibilidad Disponibilidad { get; set; }
        public String Direccion { get; set; }
        public String Latitud { get; set; }
        public String Longitud { get; set; }
        //public DateTime FechaInicio { get; set; }
        //public DateTime FechaFin { get; set; }
    }
} 