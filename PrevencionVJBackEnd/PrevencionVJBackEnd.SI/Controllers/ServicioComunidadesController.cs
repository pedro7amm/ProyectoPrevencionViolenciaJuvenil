using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioComunidadesController : ControllerBase
    {
        private readonly IAdministradorComunidades _admin;

        public ServicioComunidadesController(IAdministradorComunidades admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Comunidad>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Comunidad>> ObtenerPorId(int id)
        {
            var comunidad = await _admin.ObtenerPorIdAsync(id);
            if (comunidad == null)
                return NotFound();
            return Ok(comunidad);
        }

        [HttpGet("ObtenerPorDireccion")]
        public async Task<ActionResult<IEnumerable<Comunidad>>> ObtenerPorDireccion(int idDireccion)
        {
            return Ok(await _admin.ObtenerPorDireccionAsync(idDireccion));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Comunidad comunidad)
        {
            await _admin.AgregarAsync(comunidad);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Comunidad comunidad)
        {
            await _admin.EditarAsync(comunidad);
            return Ok();
        }
    }
}
