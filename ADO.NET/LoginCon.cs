
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionWebApi
{
    public class LoginController
    {
        public static string LogIn(string usuarioNombre, string usuarioPass)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {

                SqlCommand command = new SqlCommand("SELECT * FROM Usuario where NombreUsuario=@usuarioNombre and Contraseña=@usuarioPass", conn);

                var parameterUser = new SqlParameter();
                parameterUser.ParameterName = "nombreUsuario";
                parameterUser.SqlDbType = SqlDbType.VarChar;
                parameterUser.Value = usuarioNombre;

                var parameterPass = new SqlParameter();
                parameterPass.ParameterName = "Contraseña";
                parameterPass.SqlDbType = SqlDbType.VarChar;
                parameterPass.Value = usuarioPass;

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Usuario Usuario = new Usuario();

                    reader.Read();

                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.NombreUsuario = reader.GetString(3);
                    usuario.Mail = reader.GetString(5);
                    Console.WriteLine("Usuario encontrado");
                    
                    return usuario;
                
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado");
                    return null;
                }
            }
        }
    }
}

