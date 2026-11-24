using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioUsuariosController : ControllerBase
    {
        private readonly IAdministradorUsuarios _admin;

        public ServicioUsuariosController(IAdministradorUsuarios admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerActivos")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerActivos()
        {
            return Ok(await _admin.ObtenerActivosAsync());
        }

        [HttpGet("ObtenerInactivos")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerInactivos()
        {
            return Ok(await _admin.ObtenerInactivosAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Usuario>> ObtenerPorId(int id)
        {
            var usuario = await _admin.ObtenerPorIdAsync(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpGet("ObtenerPorCedula")]
        public async Task<ActionResult<Usuario>> ObtenerPorCedula(string cedula)
        {
            var usuario = await _admin.ObtenerPorCedulaAsync(cedula);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpGet("ObtenerPorComunidad")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerPorComunidad(int idComunidad)
        {
            return Ok(await _admin.ObtenerPorComunidadAsync(idComunidad));
        }

        [HttpGet("ObtenerPorTipo")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerPorTipo(int idTipoUsuario)
        {
            return Ok(await _admin.ObtenerPorTipoAsync(idTipoUsuario));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Usuario usuario)
        {
            await _admin.AgregarAsync(usuario);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Usuario usuario)
        {
            await _admin.EditarAsync(usuario);
            return Ok();
        }

        [HttpPut("Activar")]
        public async Task<IActionResult> Activar(int id)
        {
            await _admin.ActivarAsync(id);
            return Ok();
        }

        [HttpPut("DesActivar")]
        public async Task<IActionResult> DesActivar(int id)
        {
            await _admin.DesActivarAsync(id);
            return Ok();
        }
    }
}
