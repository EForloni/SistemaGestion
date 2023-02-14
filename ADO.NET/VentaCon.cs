
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionWebApi
{
    public class VentaController
    {
        public static string cadenaConexion = "Data Source=DESKTOP-HPHJBO6;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Venta> obtenerVentas(long id,int idusuario)
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario=@idUsuario", conn);

                var parameter = new SqlParameter();
                parameter.ParameterName = "IdUsuario";
                parameter.SqlDbType = SqlDbType.BigInt;
                parameter.Value = idusuario;

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta producto = new Venta();

                        producto.id = (int)reader.GetInt64(0);
                        producto.comentarios = reader.GetString(1);
                        producto.idusuario = (int)reader.GetInt64(5);

                        ventas.Add(producto);
                    }
                }
            }
            return ventas;
        }
    }
}

