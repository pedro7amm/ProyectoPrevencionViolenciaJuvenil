using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioParticipacionesController : ControllerBase
    {
        private readonly IAdministradorParticipaciones _admin;

        public ServicioParticipacionesController(IAdministradorParticipaciones admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Participacion>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Participacion>> ObtenerPorId(int id)
        {
            var participacion = await _admin.ObtenerPorIdAsync(id);
            if (participacion == null)
                return NotFound();
            return Ok(participacion);
        }

        [HttpGet("ObtenerPorUsuario")]
        public async Task<ActionResult<IEnumerable<Participacion>>> ObtenerPorUsuario(int idUsuario)
        {
            return Ok(await _admin.ObtenerPorUsuarioAsync(idUsuario));
        }

        [HttpGet("ObtenerPorActividad")]
        public async Task<ActionResult<IEnumerable<Participacion>>> ObtenerPorActividad(int idActividad)
        {
            return Ok(await _admin.ObtenerPorActividadAsync(idActividad));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Participacion participacion)
        {
            await _admin.AgregarAsync(participacion);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Participacion participacion)
        {
            await _admin.EditarAsync(participacion);
            return Ok();
        }
    }
}
