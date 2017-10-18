using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using WebUI.Entities;
using WebUI.Utilities;

namespace WebUI.Manager
{
    public class ArbolManager
    {
        public static List<Arbol> GetTodos()
        {
            List<Arbol> arboles = new List<Arbol>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Arbol", con);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Arbol arbol = MapearArbol(dr);
                        arboles.Add(arbol);
                    }
                }
            }
            return arboles;
        }

        public static IEnumerable<Arbol> GetArboles(int IdUsuario)
        {
            List<Arbol> arboles = new List<Arbol>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Arbol WHERE IdUsuario = @IdUsuario", con);
                query.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Arbol arbol = MapearArbol(dr);
                        arboles.Add(arbol);
                    }
                }
            }
            return arboles;
        }

        public static List<Arbol> GetArbolesByVariedad(String variedad, int? IdUsuario)
        {
            var consulta = "SELECT * FROM Arbol WHERE Variedad = @variedad AND Disponibilidad != 'nula'";
            if (IdUsuario != null)
            {
                consulta += " AND IdUsuario != " + IdUsuario;
            }
            List<Arbol> arboles = new List<Arbol>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand(consulta, con);
                query.Parameters.AddWithValue("@variedad", variedad);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Arbol arbol = MapearArbol(dr);
                        arboles.Add(arbol);
                    }
                }
            }
            return arboles;
        }

        public static Arbol GetArbol(int Id)
        {
            Arbol arbol = new Arbol();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Arbol WHERE Id = @Id", con);
                query.Parameters.AddWithValue("@Id", Id);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        arbol = MapearArbol(dr);
                    }
                }
            }
            return arbol;
        }

        public static void Nuevo(Arbol unArbol)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("INSERT INTO Arbol (IdUsuario, Variedad, Disponibilidad, Direccion, Latitud, Longitud) VALUES (@IdUsuario, @Variedad, @Disponibilidad, @Direccion, @Latitud, @Longitud)", con);

                query.Parameters.AddWithValue("@IdUsuario", unArbol.IdUsuario);
                query.Parameters.AddWithValue("@Variedad", unArbol.Variedad.ToString());
                query.Parameters.AddWithValue("@Disponibilidad", unArbol.Disponibilidad.ToString());
                query.Parameters.AddWithValue("@Direccion", unArbol.Direccion);
                query.Parameters.AddWithValue("@Latitud", unArbol.Latitud);
                query.Parameters.AddWithValue("@Longitud", unArbol.Longitud);

                query.ExecuteNonQuery();
            }
        }

        public static void Editar(Arbol unArbol)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("UPDATE Arbol SET IdUsuario = @IdUsuario, Variedad = @Variedad, Disponibilidad = @Disponibilidad, Direccion = @Direccion, Latitud = @Latitud, Longitud = @Longitud WHERE Id = @Id", con);

                query.Parameters.AddWithValue("@Id", unArbol.Id);
                query.Parameters.AddWithValue("@IdUsuario", unArbol.IdUsuario);
                query.Parameters.AddWithValue("@Variedad", unArbol.Variedad.ToString());
                query.Parameters.AddWithValue("@Disponibilidad", unArbol.Disponibilidad.ToString());
                query.Parameters.AddWithValue("@Direccion", unArbol.Direccion);
                query.Parameters.AddWithValue("@Latitud", unArbol.Latitud);
                query.Parameters.AddWithValue("@Longitud", unArbol.Longitud);

                query.ExecuteNonQuery();
            }
        }

        public static void Borrar(int Id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("DELETE FROM Arbol WHERE Id = @Id", con);

                query.Parameters.AddWithValue("@Id", Id);

                query.ExecuteNonQuery();
            }
        }

        private static Arbol MapearArbol(SqlDataReader dr)
        {
            Arbol arbol = new Arbol
            {
                Id = Convert.ToInt32(dr["Id"]),
                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                Variedad = (EVariedad)Enum.Parse(typeof(EVariedad), dr["Variedad"].ToString()),                
                Disponibilidad = (EDisponibilidad)Enum.Parse(typeof(EDisponibilidad), dr["Disponibilidad"].ToString()),
                Direccion = dr["Direccion"].ToString(),
                Latitud = dr["Latitud"].ToString(),
                Longitud = dr["Longitud"].ToString()
            };
            return arbol;
        }

        public static JObject CalcularDistancia(string origin, string destination)
        {
            string url = @"http://maps.googleapis.com/maps/api/distancematrix/json?origins=" +
              origin + "&destinations=" + destination +
              "&mode=driving&sensor=false&language=es-ES&";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            JObject json = JObject.Parse(responsereader);
            response.Close();

            return json ;
        }

    }
}