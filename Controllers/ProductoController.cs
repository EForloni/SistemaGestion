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
            Producto producto = ProductoController.obtenerProducto(descripciones);
            return producto;
        }
    }
}
