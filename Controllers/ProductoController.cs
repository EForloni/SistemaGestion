using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.Intrinsics.X86;


namespace SistemaGestionWebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet("/producto/{descripciones}")]
        public Producto ObtenerProductoPorDescripciones(string descripciones)
        {
            Producto producto = ProductoCon.obtenerProducto(descripciones);
            return producto;
        }

        [HttpPost("/producto/")]
        public void CrearProducto(Producto producto)
        {
            ProductoCon.InsertarProducto(producto);
        }
        [HttpPut("/producto/")]
        public void ModificarProducto(Producto producto)
        {
            ProductoCon.ModificarProducto(producto);
        }
        [HttpDelete("/producto/{id}")]
        public void EliminarProducto (int id)
        {
            ProductoCon.EliminarProducto(id);
        }
    }
}
