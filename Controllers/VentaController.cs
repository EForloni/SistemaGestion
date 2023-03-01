using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Intrinsics.X86;


namespace SistemaGestionWebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        [HttpGet("/Ventas/{idusuario}/")]  //Traer Ventas
        public void TraerVentas(int idusuario)
        {
            VentaCon.obtenerVentas(idusuario);
        }

        [HttpPost("/Ventas/{idusuario}/")]  //Cargar Ventas
        public void CargarVentas (List<Producto> productos, int idUsuario)
        {
            VentaCon.CargarVenta(idUsuario, productos);
        }

    }
}
