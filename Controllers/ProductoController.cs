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
        [HttpPost("/Producto/")] // Crear producto
        public void CrearProducto(Producto producto)
        {
            ProductoCon.InsertarProducto(producto);
        }

        [HttpPut("/Producto/")] // Modificar producto
        public void ModificarProducto(Producto producto)
        {
            ProductoCon.ModificarProducto(producto);
        }

        [HttpDelete("/Producto/{id}")] // Eliminar producto
        public void EliminarProducto (int id)
        {
            ProductoCon.EliminarProducto(id);
        }

        [HttpGet("/Producto/{id}/")]  //Traer Producto
        public void TraerProducto (int id)
        {
            ProductoCon.ObtenerProducto(id);
        }
    }
}
