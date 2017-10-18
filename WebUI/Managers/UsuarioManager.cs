using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WebUI.Areas.Dashboard.ViewModels;
using WebUI.Entities;
using WebUI.Utilities;

namespace WebUI.Manager
{
    public class UsuarioManager
    {
        public static Usuario GetByNombreUsuario(string nombreUsuario)
        {
            Usuario usuario = null;
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario", con);
                query.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario = MapearUsuario(dr);
                    }
                }
            }
            return usuario;
        }

        public static Usuario GetByEmail(string email)
        {
            Usuario usuario = null;
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Usuario WHERE email = @email", con);
                query.Parameters.AddWithValue("@email", email);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario = MapearUsuario(dr);
                    }
                }
            }
            return usuario;
        }

        public static Usuario Get(int id)
        {
            Usuario usuario = null;
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Usuario WHERE id = @id", con);
                query.Parameters.AddWithValue("@id", id);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario = MapearUsuario(dr);
                    }
                }
            }
            return usuario;
        }

        public static Usuario Login(string nombreUsuario, string pass)
        {
            Usuario usuario = null;
            string passwordEncriptada = Constantes.Encriptar(pass);
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Usuario WHERE nombreUsuario = @nombreUsuario AND Pass = @pass", con);
                query.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                query.Parameters.AddWithValue("@pass", passwordEncriptada);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario = MapearUsuario(dr);
                    }
                }
            }
            return usuario;

        }

        public static void Nuevo(Usuario usuario)
        {
            string passwordEncriptada = Constantes.Encriptar(usuario.Pass);
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("INSERT INTO Usuario (Nombre, NombreUsuario, Email, Pass) VALUES (@Nombre, @Nombreusuario, @Email, @Pass)", con);

                query.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                query.Parameters.AddWithValue("@Nombreusuario", usuario.NombreUsuario);
                query.Parameters.AddWithValue("@Email", usuario.Email);
                query.Parameters.AddWithValue("@Pass", passwordEncriptada);

                query.ExecuteNonQuery();
            }
        }

        public static void Editar(Usuario usuario) {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("UPDATE Usuario set Nombre = @nombre, Nombreusuario = @Nombreusuario, Email = @Email WHERE Id = @Id", con);

                query.Parameters.AddWithValue("@Id", usuario.Id);
                query.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                query.Parameters.AddWithValue("@Nombreusuario", usuario.NombreUsuario);
                query.Parameters.AddWithValue("@Email", usuario.Email);

                query.ExecuteNonQuery();
            }
        }

        public static void EditarContraseña(List<Usuario> usuarios)
        {
            //usuarios[0] es el usuario con pass anterior
            //usuarios[1] es el usuario con pass nueva
            Usuario usuario = new Usuario();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();
                //traigo el usuario en BD para comparar con la pass ya guardada
                var query = new SqlCommand("SELECT * FROM Usuario WHERE id = @id", con);
                query.Parameters.AddWithValue("@id", usuarios[0].Id);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario = MapearUsuario(dr);
                    }
                }
            }
            string passwordAnteriorEncriptada = Constantes.Encriptar(usuarios[0].Pass);
            if (usuario.Pass == passwordAnteriorEncriptada)//verifico que la pass ingresada por formulario como "anterior" coincida con la ya guardada en BD(ambas encriptadas)
            {
                string passwordNuevaEncriptada = Constantes.Encriptar(usuarios[1].Pass);
                InsertarContraseña(usuario.Id, passwordNuevaEncriptada);
            }

        }

        public static Boolean ResetearContraseña(Usuario usuario)
        {
            string nuevoPass = Constantes.GenerarRandom();
            string nuevoPassEncriptada = Constantes.Encriptar(nuevoPass);
            InsertarContraseña(usuario.Id, nuevoPassEncriptada);
            StringBuilder Mensaje = new StringBuilder();
            Mensaje.Append("Hola " + usuario.Nombre +", <br>");
            Mensaje.Append("Esta es tu nueva contraseña: <br>" + nuevoPass);
            Email.Enviar(usuario.Email, "Esteban", "Reseteo de Cuenta", Mensaje.ToString());
            return true;
        }

        private static void InsertarContraseña(int Id, string passwordEncriptada)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("UPDATE Usuario SET Pass = @Pass WHERE Id = @Id", con);

                query.Parameters.AddWithValue("@Id", Id);
                query.Parameters.AddWithValue("@Pass", passwordEncriptada);

                query.ExecuteNonQuery();
            }
        }

        public static Boolean EmailUnico(string email)
        {
            Boolean esUnico = true;
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Usuario WHERE email = @email", con);
                query.Parameters.AddWithValue("@email", email);
                using (var dr = query.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        esUnico = false;
                    }
                }
            }
            return esUnico;
        }

        public static Boolean NombreUsuarioUnico(string nombreUsuario)
        {
            Boolean esUnico = true;
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.KeyConnectionStringComIT].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario", con);
                query.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                using (var dr = query.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        esUnico = false;
                    }
                }
            }
            return esUnico;
        }


        private static Usuario MapearUsuario(SqlDataReader dr)
        {
            var usuario = new Usuario
            {
                Id = Convert.ToInt32(dr["Id"]),
                Nombre = dr["Nombre"].ToString(),
                NombreUsuario = dr["NombreUsuario"].ToString(),
                Email = dr["Email"].ToString(),
                Pass = dr["Pass"].ToString()
            };
            return usuario;
        }
    }
}