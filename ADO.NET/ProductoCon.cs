
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionWebApi
{
    public class ProductoController
    {
        public static string cadenaConexion = "Data Source=DESKTOP-HPHJBO6;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Producto obtenerProducto(string Descripciones)
        {
            Producto producto = new Producto();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE Descripciones=@Descripciones", conn);

                var parameter = new SqlParameter();
                parameter.ParameterName = "Descripciones";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Value = Descripciones;

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

        public static List<Producto> obtenerProductos(long id)
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario=@id", conn);

                var parameter = new SqlParameter();
                parameter.ParameterName = "Id";
                parameter.SqlDbType = SqlDbType.BigInt;
                parameter.Value = id;

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();

                        producto.id = (int)reader.GetInt64(0);
                        producto.descripciones = reader.GetString(1);
                        producto.costo = (int)reader.GetDecimal(2);
                        producto.precioventa = (int)reader.GetDecimal(3);
                        producto.stock = (int)reader.GetInt32(4);
                        producto.idusuario = (int)reader.GetInt64(5);

                        productos.Add(producto);
                    }
                }
            }
            return productos;
        }
    }

}