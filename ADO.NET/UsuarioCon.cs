﻿
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace SistemaGestionWebApi
{
    public class UsuarioCon
    {
        public static string cadenaConexion = "Data Source=DESKTOP-HPHJBO6;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Usuario> obtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Usuario", conn);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reader.Read();

                        Usuario usuario = new Usuario();

                        usuario.Id = (int)reader.GetInt64(0);
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Contraseña = reader.GetString(4);
                        usuario.Mail = reader.GetString(5);

                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

        public static Usuario obtenerUsuario(long id)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {

                SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE Id=@id", conn);

                var parameter = new SqlParameter();
                parameter.ParameterName = "Id";
                parameter.SqlDbType = SqlDbType.BigInt;
                parameter.Value = id;

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    usuario.Id = (int)reader.GetInt64(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.NombreUsuario = reader.GetString(3);
                    usuario.Contraseña = reader.GetString(4);
                    usuario.Mail = reader.GetString(5);

                }

            }
            return usuario;
        }
        public static Usuario ModificarUsuario(Usuario usuario)
        {

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand();

                comando.Connection = conn;
                comando.Connection.Open();
                comando.CommandText = @"UPDATE Usuario SET [Nombre] = @nombre, [Apellido] =  @apellido, [NombreUsuario] =  @nombreUsuario, [Contraseña] =  @contraseña, [Mail] = @mail WHERE id = @ID";

                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                comando.Parameters.AddWithValue("@mail", usuario.Mail);
                comando.Parameters.AddWithValue("@ID", usuario.Id);
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }

            return usuario;
        }
    }
}

