using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.Intrinsics.X86;


namespace SistemaGestionWebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("/ProductoVendido/{id}/")]  //Traer Productos Vendidos
        public void TraerProductoVendido (int idusuario)
        {
            ProductoVendidoCon.obtenerProductosVendidos(idusuario);
        }
    }
}
