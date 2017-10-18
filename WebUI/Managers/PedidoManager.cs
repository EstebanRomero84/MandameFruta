using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebUI.Entities;
using WebUI.Utilities;

namespace WebUI.Manager
{
    public class PedidoManager
    {
        public static Pedido GetPedido(int id)
        {
            Pedido pedido = new Pedido();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand(@"SELECT p.Id, p.Arbol AS ArbolId, a.Variedad AS ArbolVariedad, a.Disponibilidad AS ArbolDisponibilidad, p.Emisor AS EmisorId, us.Nombre AS EmisorNombre, us.NombreUsuario AS EmisorNombreUsuario,
                                           us.Email AS EmisorEmail, u.Id AS ReceptorId, u.Nombre AS ReceptorNombre, u.NombreUsuario AS ReceptorNombreUsuario, u.Email AS ReceptorEmail, pa.IdArbol AS OfertaId, o.Variedad AS OfertaVariedad,
                                           o.Disponibilidad AS OfertaDisponibilidad, p.Estado, p.Visto, p.Fecha
                                           FROM Pedido p INNER JOIN Pedido_Arbol pa ON p.Id = pa.IdPedido
                                                         INNER JOIN Arbol a ON p.Arbol = a.Id
                                                         INNER JOIN Arbol o ON pa.IdArbol = o.Id
                                                         INNER JOIN Usuario us ON p.Emisor = us.Id
                                                         INNER JOIN Usuario u ON p.Receptor = u.Id
                                           WHERE p.Id = @Id", con);
                query.Parameters.AddWithValue("@Id", id);
                List<Arbol> oferta = new List<Arbol>();
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        pedido = MapearPedido(dr);
                        Arbol arbol = MapearOferta(dr);
                        oferta.Add(arbol);
                    }
                }
                pedido.Oferta = oferta;
            }
            return pedido;
        }

        public static Pedido GetPedido(int IdUsuario, int id)
        {
            Pedido pedido = new Pedido();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand(@"SELECT p.Id, p.Arbol AS ArbolId, a.Variedad AS ArbolVariedad, a.Disponibilidad AS ArbolDisponibilidad, p.Emisor AS EmisorId, us.Nombre AS EmisorNombre, us.NombreUsuario AS EmisorNombreUsuario,
                                           us.Email AS EmisorEmail, u.Id AS ReceptorId, u.Nombre AS ReceptorNombre, u.NombreUsuario AS ReceptorNombreUsuario, u.Email AS ReceptorEmail, pa.IdArbol AS OfertaId, o.Variedad AS OfertaVariedad,
                                           o.Disponibilidad AS OfertaDisponibilidad, p.Estado, p.Visto, p.Fecha
                                           FROM Pedido p INNER JOIN Pedido_Arbol pa ON p.Id = pa.IdPedido
                                                         INNER JOIN Arbol a ON p.Arbol = a.Id
                                                         INNER JOIN Arbol o ON pa.IdArbol = o.Id
                                                         INNER JOIN Usuario us ON p.Emisor = us.Id
                                                         INNER JOIN Usuario u ON p.Receptor = u.Id
                                           WHERE p.Id = @Id", con);
                query.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                query.Parameters.AddWithValue("@Id", id);
                List<Arbol> oferta = new List<Arbol>();
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        pedido = MapearPedido(dr);
                        if (pedido.Visto == "NoVisto")
                        {
                            SetVisto(id);
                        }
                        Arbol arbol = MapearOferta(dr);
                        oferta.Add(arbol);
                    }
                }
                pedido.Oferta = oferta;
            }
            return pedido;
        }

        public static IEnumerable<Pedido> GetRecibidos(int IdUsuario)
        {
            List<Pedido> pedidos = new List<Pedido>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand(@"SELECT p.Id, p.Arbol AS ArbolId, a.Variedad AS ArbolVariedad, a.Disponibilidad AS ArbolDisponibilidad, p.Emisor AS EmisorId, us.Nombre AS EmisorNombre, us.NombreUsuario AS EmisorNombreUsuario,
                                           us.Email AS EmisorEmail, u.Id AS ReceptorId, u.Nombre AS ReceptorNombre, u.NombreUsuario AS ReceptorNombreUsuario, u.Email AS ReceptorEmail, pa.IdArbol AS OfertaId, o.Variedad AS OfertaVariedad,
                                           o.Disponibilidad AS OfertaDisponibilidad, p.Estado, p.Visto, p.Fecha
                                           FROM Pedido p INNER JOIN Pedido_Arbol pa ON p.Id = pa.IdPedido
                                                         INNER JOIN Arbol a ON p.Arbol = a.Id
                                                         INNER JOIN Arbol o ON pa.IdArbol = o.Id
                                                         INNER JOIN Usuario us ON p.Emisor = us.Id
                                                         INNER JOIN Usuario u ON p.Receptor = u.Id
                                           WHERE p.Receptor = @Id AND VisibleReceptor = '1' ORDER BY Fecha DESC", con);
                query.Parameters.AddWithValue("@Id", IdUsuario);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Pedido pedido = MapearPedido(dr);
                        var pedidoAuxiliar = pedidos.Find(px => px.IdPedido == pedido.IdPedido);//pregunto si el pedido que acabo de mapear ya esta agregado en la lista
                        if (pedidoAuxiliar == null)
                        {
                            pedidos.Add(pedido);
                        }
                    }
                }
            }
            return pedidos;
        }

        public static IEnumerable<Pedido> GetEnviados(int IdUsuario)
        {
            List<Pedido> pedidos = new List<Pedido>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand(@"SELECT p.Id, p.Arbol AS ArbolId, a.Variedad AS ArbolVariedad, a.Disponibilidad AS ArbolDisponibilidad, p.Emisor AS EmisorId, us.Nombre AS EmisorNombre, us.NombreUsuario AS EmisorNombreUsuario,
                                           us.Email AS EmisorEmail, u.Id AS ReceptorId, u.Nombre AS ReceptorNombre, u.NombreUsuario AS ReceptorNombreUsuario, u.Email AS ReceptorEmail, pa.IdArbol AS OfertaId, o.Variedad AS OfertaVariedad,
                                           o.Disponibilidad AS OfertaDisponibilidad, p.Estado, p.Visto, p.Fecha
                                           FROM Pedido p INNER JOIN Pedido_Arbol pa ON p.Id = pa.IdPedido
                                                         INNER JOIN Arbol a ON p.Arbol = a.Id
                                                         INNER JOIN Arbol o ON pa.IdArbol = o.Id
                                                         INNER JOIN Usuario us ON p.Emisor = us.Id
                                                         INNER JOIN Usuario u ON p.Receptor = u.Id
                                           WHERE p.Emisor = @Id AND VisibleEmisor = '1' ORDER BY Fecha DESC", con);
                query.Parameters.AddWithValue("@Id", IdUsuario);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Pedido pedido = MapearPedido(dr);
                        var pedidoAuxiliar = pedidos.Find(px => px.IdPedido == pedido.IdPedido);//pregunto si el pedido que acabo de mapear ya esta agregado en la lista
                        if (pedidoAuxiliar == null)
                        {
                            pedidos.Add(pedido);
                        }
                    }
                }
            }
            return pedidos;
        }

        public static void Nuevo(Pedido pedido) {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("INSERT INTO Pedido (Arbol, Emisor, Receptor, Estado, Visto, Fecha) VALUES (@Arbol, @Emisor, @Receptor, 'Pendiente', 'novisto', @Fecha ) SET @ID = SCOPE_IDENTITY();", con);

                query.Parameters.AddWithValue("@Arbol", pedido.Arbol.Id);
                query.Parameters.AddWithValue("@Emisor", pedido.Emisor.Id);
                query.Parameters.AddWithValue("@Receptor", pedido.Receptor.Id);
                query.Parameters.AddWithValue("@Fecha", DateTime.Now);
                //Tengo que recuperar el id del pedido recien insertado para despues agregar los arboles a la tabla Pedido_Arbol
                //Para ello utilizo SCOPE_IDENTITY() y lo configuro en la siguiente linea
                query.Parameters.Add("@id", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                query.ExecuteNonQuery();
                pedido.IdPedido = (int)query.Parameters["@id"].Value;

                foreach (Arbol arbol in pedido.Oferta)
                {
                    query = new SqlCommand("INSERT INTO Pedido_Arbol (IdPedido, IdArbol) VALUES (@IdPedido, @IdArbol)", con);

                    query.Parameters.AddWithValue("@IdPedido", pedido.IdPedido);
                    query.Parameters.AddWithValue("@IdArbol", arbol.Id);

                    query.ExecuteNonQuery();
                }
            }
        }

        public static void Eliminar(int idPedido, String visible)
        {
            String consulta = "";
            switch (visible)
            {
                case "VisibleReceptor": consulta = "UPDATE Pedido SET VisibleReceptor = '0' WHERE Id = @IdPedido"; break;
                case "VisibleEmisor": consulta = "UPDATE Pedido SET VisibleEmisor = '0' WHERE Id = @IdPedido"; break;
                default: break;
            }
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand(consulta, con);

                query.Parameters.AddWithValue("@IdPedido", idPedido);

                query.ExecuteNonQuery();
            }
        }

        public static void SetVisto(int idPedido) {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("UPDATE Pedido SET Visto = 'visto' WHERE Id = @IdPedido", con);

                query.Parameters.AddWithValue("@IdPedido", idPedido);

                query.ExecuteNonQuery();
            }
        }

        public static void Rechazar(int idPedido)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("UPDATE Pedido SET Estado = 'Rechazado' WHERE Id = @IdPedido", con);

                query.Parameters.AddWithValue("@IdPedido", idPedido);

                query.ExecuteNonQuery();
            }
        }

        public static void Aceptar(int idPedido)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("UPDATE Pedido SET Estado = 'Aceptado' WHERE Id = @IdPedido", con);

                query.Parameters.AddWithValue("@IdPedido", idPedido);

                query.ExecuteNonQuery();
            }
        }

        private static Arbol MapearOferta(SqlDataReader dr)//TODO:analizar si se puede implementar junto con mapear arbol de ArbolManager
        {
            Arbol arbol = new Arbol
            {
                Id = Convert.ToInt32(dr["OfertaId"]),
                IdUsuario = Convert.ToInt32(dr["ReceptorId"]),
                Variedad = (EVariedad)Enum.Parse(typeof(EVariedad), dr["OfertaVariedad"].ToString()),
                Disponibilidad = (EDisponibilidad)Enum.Parse(typeof(EDisponibilidad), dr["OfertaDisponibilidad"].ToString())
            };
            return arbol;
        }

        private static Pedido MapearPedido(SqlDataReader dr)
        {
            Pedido pedido = new Pedido
            {
                IdPedido = Convert.ToInt32(dr["Id"]),
                Arbol = new Arbol
                {
                    Id = Convert.ToInt32(dr["ArbolId"]),
                    Variedad = (EVariedad)Enum.Parse(typeof(EVariedad), dr["ArbolVariedad"].ToString()),
                    Disponibilidad = (EDisponibilidad)Enum.Parse(typeof(EDisponibilidad), dr["ArbolDisponibilidad"].ToString())
                },
                Emisor = new Usuario
                {
                    Id = Convert.ToInt32(dr["EmisorId"]),
                    Nombre = dr["EmisorNombre"].ToString(),
                    NombreUsuario = dr["EmisorNombreUsuario"].ToString(),
                    Email = dr["EmisorEmail"].ToString(),
                },
                Receptor = new Usuario
                {
                    Id = Convert.ToInt32(dr["ReceptorId"]),
                    Nombre = dr["ReceptorNombre"].ToString(),
                    NombreUsuario = dr["ReceptorNombreUsuario"].ToString(),
                    Email = dr["ReceptorEmail"].ToString(),
                },
                Estado = dr["Estado"].ToString(),
                Visto = dr["Visto"].ToString(),
                Fecha = Convert.ToDateTime(dr["Fecha"])
            };
            return pedido;
        }
    }
}
//TODO: editar contraseña
//TODO: recuperar contraseña
//TODO: crear cuenta nueva