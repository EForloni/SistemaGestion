using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaGestionWebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPut("/usuario/")]

        public void ModificarUsuarios(Usuario usuario)
        {
            UsuarioCon.ModificarUsuario(usuario);
        }
    }
}
