using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaGestionWebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("/Usuario/{usuario}/{contrasena}/")] //Iniciar sesion
        public void LogIns(string usuarioNombre, string usuarioPass)
        {
            LoginCon.LogIn(usuarioNombre, usuarioPass);
        }

        [HttpPost("/Usuario/")] //Crear usuario
        public void CrearUsuario(Usuario usuario)
        {
            UsuarioCon.InsertarUsuario(usuario);
        }

        [HttpPut("/Usuario/")] //Modificar usuario
        public void ModificarUsuarios(Usuario usuario)
        {
            UsuarioCon.ModificarUsuario(usuario);
        }

        [HttpGet("/Usuario/{usuario}/")] //Traer Usuario
        public void TraerUsuarios(string usuario)
        {
            UsuarioCon.TraerUsuario(usuario);
        }

        [HttpDelete("/Usuario/{id}/")] //Eliminar Usuario
        public void EliminarUsuarios(int id)
        {
            UsuarioCon.EliminarUsuario(id);
        }
    }
}
