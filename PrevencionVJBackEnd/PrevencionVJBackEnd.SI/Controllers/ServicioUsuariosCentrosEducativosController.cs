using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioUsuariosCentrosEducativosController : ControllerBase
    {
        private readonly IAdministradorUsuariosCentrosEducativos _admin;

        public ServicioUsuariosCentrosEducativosController(
            IAdministradorUsuariosCentrosEducativos admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<UsuarioCentroEducativo>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerActivos")]
        public async Task<ActionResult<IEnumerable<UsuarioCentroEducativo>>> ObtenerActivos()
        {
            return Ok(await _admin.ObtenerActivosAsync());
        }

        [HttpGet("ObtenerInactivos")]
        public async Task<ActionResult<IEnumerable<UsuarioCentroEducativo>>> ObtenerInactivos()
        {
            return Ok(await _admin.ObtenerInactivosAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<UsuarioCentroEducativo>> ObtenerPorId(int id)
        {
            var registro = await _admin.ObtenerPorIdAsync(id);
            if (registro == null)
                return NotFound();
            return Ok(registro);
        }

        [HttpGet("ObtenerPorUsuario")]
        public async Task<ActionResult<IEnumerable<UsuarioCentroEducativo>>> ObtenerPorUsuario(
            int idUsuario)
        {
            return Ok(await _admin.ObtenerPorUsuarioAsync(idUsuario));
        }

        [HttpGet("ObtenerPorCentroEducativo")]
        public async Task<ActionResult<IEnumerable<UsuarioCentroEducativo>>>
            ObtenerPorCentroEducativo(int idCentroEducativo)
        {
            return Ok(await _admin.ObtenerPorCentroEducativoAsync(idCentroEducativo));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar(
            [FromBody] UsuarioCentroEducativo usuarioCentroEducativo)
        {
            await _admin.AgregarAsync(usuarioCentroEducativo);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar(
            [FromBody] UsuarioCentroEducativo usuarioCentroEducativo)
        {
            await _admin.EditarAsync(usuarioCentroEducativo);
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
