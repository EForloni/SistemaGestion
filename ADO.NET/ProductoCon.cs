
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SistemaGestionWebApi
{
    public class ProductoCon
    {
        public static string cadenaConexion = "Data Source=DESKTOP-HPHJBO6;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Producto> ObtenerProducto(long id)
        {

            var listaProductos = new List<Producto>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {

                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario=@IdUsuario", conn);
                comando.Parameters.AddWithValue("@idUsuario", id);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.id = reader.GetInt32(0);
                        producto.descripciones = reader.GetString(1);
                        producto.costo = reader.GetInt32(2);
                        producto.precioventa = reader.GetInt32(3);
                        producto.stock = reader.GetInt32(4);
                        producto.idusuario = reader.GetInt32(5);

                        listaProductos.Add(producto);
                    }
                }
                return listaProductos;
            }
        }
       
        public static Producto InsertarProducto(Producto producto)
        {

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand();

                comando.Connection = conn;
                comando.Connection.Open();
                comando.CommandText = @"INSERT INTO Producto([Descripciones],[Costo], [PrecioVenta], [Stock], [IdUsuario]) VALUES(@descripciones, @costo, @precioVenta, @stock, @idUsuario)";
                comando.Parameters.AddWithValue("@descripciones", producto.descripciones);
                comando.Parameters.AddWithValue("@costo", producto.costo);
                comando.Parameters.AddWithValue("@precioVenta", producto.precioventa);
                comando.Parameters.AddWithValue("@stock", producto.stock);
                comando.Parameters.AddWithValue("@idUsuario", producto.idusuario);
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }

            return producto;
        }
        public static Producto ModificarProducto(Producto producto)
        {

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand();

                comando.Connection = conn;
                comando.Connection.Open();
                comando.CommandText = @"UPDATE Producto SET [Descripciones]= @descripciones, [Costo]= @costo, [PrecioVenta]= @precioVenta, [Stock]=@stock WHERE [Id]=@ID";


                comando.Parameters.AddWithValue("@descripciones", producto.descripciones);
                comando.Parameters.AddWithValue("@costo", producto.costo);
                comando.Parameters.AddWithValue("@precioVenta", producto.precioventa);
                comando.Parameters.AddWithValue("@stock", producto.stock);
                comando.Parameters.AddWithValue("@ID", producto.id);
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }

            return producto;
        }
        public static int EliminarProducto(int id)
        {

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand();

                comando.Connection = conn;
                comando.Connection.Open();
                comando.CommandText = @"DELETE [ProductoVendido] WHERE [IdProducto]=@ID";

                comando.Parameters.AddWithValue("@ID", id);
                comando.ExecuteNonQuery();

                comando.CommandText = @"DELETE [Producto] WHERE [Id]=@ID";

                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }

            return id;
        }
    }
}