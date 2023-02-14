
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionWebApi
{
    public class UsuarioController
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
    }
}

