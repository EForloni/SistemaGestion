
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionWebApi
{
    public class ProductoCon
    {
        public static string cadenaConexion = "Data Source=DESKTOP-HPHJBO6;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Producto obtenerProducto(string descripciones)
        {
            Producto producto = new Producto();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE Descripciones=@descripciones", conn);

                var parameter = new SqlParameter();
                parameter.ParameterName = "Descripciones";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Value = descripciones;

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    producto.id = (int)reader.GetInt64(0);
                    producto.descripciones = reader.GetString(1);
                    producto.costo = (int)reader.GetDecimal(2);
                    producto.precioventa = (int)reader.GetDecimal(3);
                    producto.stock = (int)reader.GetInt32(4);
                    producto.idusuario = (int)reader.GetInt64(5);

                }
            }
            return producto;
        }

        public static Producto obtenerProductoPorId(long id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario=@id", conn);

                var parameter = new SqlParameter();
                parameter.ParameterName = "Id";
                parameter.SqlDbType = SqlDbType.BigInt;
                parameter.Value = id;

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                Producto producto = new Producto();

                if (reader.HasRows)
                {
                        producto.id = (int)reader.GetInt64(0);
                        producto.descripciones = reader.GetString(1);
                        producto.idusuario = (int)reader.GetInt64(2);
                }
                return producto;
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


        public static Producto UpdateStockProducto(long id, int cantidadVendidos)
        {
            Producto producto = obtenerProductoPorId(id);
            producto.stock -= cantidadVendidos;
            return ModificarProducto(producto);
        }
    }
}