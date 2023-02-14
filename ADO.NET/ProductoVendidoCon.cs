
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionWebApi
{
    public class ProductoVendidoCon
    {
        public static string cadenaConexion = "Data Source=DESKTOP-HPHJBO6;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<ProductoVendido> obtenerProductosVendidos(long idUsuario)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT IdProducto FROM Venta INNER JOIN ProductoVendido ON Venta.Id = ProductoVendido.IdVenta WHERE IdUsuario = {idUsuario}", conn);

                var parameter = new SqlParameter();
                parameter.ParameterName = "IdUsuario";
                parameter.SqlDbType = SqlDbType.BigInt;
                parameter.Value = idUsuario;

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductoVendido producto = new ProductoVendido();

                            producto.id = (int)reader.GetInt64(0);
                            producto.stock = (int)reader.GetDecimal(1);
                            producto.idproducto = (int)reader.GetDecimal(2);
                            producto.idventa = (int)reader.GetDecimal(3);

                        productosVendidos.Add(producto);
                    }
                }
            }
            return productosVendidos;
        }
    }
}

