
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace SistemaGestionWebApi
{
    public class VentaCon
    {
        public static string cadenaConexion = "Data Source=DESKTOP-HPHJBO6;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Venta> obtenerVentas(int idusuario)
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

        public static void CargarVenta(int idUsuario, List<Producto> productosVendidos)
        {
            Venta venta = new Venta();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {

                SqlCommand comando = new SqlCommand();
                comando.Connection = conn;
                comando.Connection.Open();

                venta.comentarios = "";
                venta.idusuario = idUsuario;
                venta.id = (int)InsertarVenta(venta);

                foreach (Producto producto in productosVendidos)
                {
                    ProductoVendido productoVendido = new ProductoVendido();
                    productoVendido.stock = producto.stock;
                    productoVendido.idproducto = producto.id;
                    productoVendido.idventa = venta.id;

                    ProductoVendidoCon.InsertarProductoVendido(productoVendido);
                    ActualizarStockProducto(productoVendido.idproducto, productoVendido.stock);
                }
            }
        }

        public static long InsertarVenta(Venta venta)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {

                SqlCommand comando = new SqlCommand();

                comando.Connection = conn;
                comando.Connection.Open();

                comando.CommandText = "INSERT INTO Venta ([Comentarios], [IdUsuario]) VALUES( @comentarios, @idUsuario)";
                comando.Parameters.AddWithValue("@comentarios", venta.comentarios);
                comando.Parameters.AddWithValue("@idUsuario", venta.idusuario);
                comando.ExecuteNonQuery();

                comando.CommandText = "SELECT @@Identity";
                long ultimoID = Convert.ToInt64(comando.ExecuteScalar());
                comando.Connection.Close();
                return ultimoID;
            }
        }
        public static Producto ActualizarStockProducto(int id, int cantidadVendidos)
        {
            Producto producto = ProductoCon.ObtenerProducto(id);
            producto.stock -= cantidadVendidos;
            return ProductoCon.ModificarProducto(producto);
        }

    }
}

