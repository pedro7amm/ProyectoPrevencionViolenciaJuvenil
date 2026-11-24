using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioCantonesController : ControllerBase
    {
        private readonly IAdministradorCantones _admin;

        public ServicioCantonesController(IAdministradorCantones admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Canton>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerActivos")]
        public async Task<ActionResult<IEnumerable<Canton>>> ObtenerActivos()
        {
            return Ok(await _admin.ObtenerActivosAsync());
        }

        [HttpGet("ObtenerInactivos")]
        public async Task<ActionResult<IEnumerable<Canton>>> ObtenerInactivos()
        {
            return Ok(await _admin.ObtenerInactivosAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Canton>> ObtenerPorId(int id)
        {
            var canton = await _admin.ObtenerPorIdAsync(id);
            if (canton == null)
                return NotFound();
            return Ok(canton);
        }

        [HttpGet("ObtenerPorDescripcion")]
        public async Task<ActionResult<Canton>> ObtenerPorDescripcion(string descripcion)
        {
            var canton = await _admin.ObtenerPorDescripcionAsync(descripcion);
            if (canton == null)
                return NotFound();
            return Ok(canton);
        }

        [HttpGet("ObtenerPorProvincia")]
        public async Task<ActionResult<IEnumerable<Canton>>> ObtenerPorProvincia(int idProvincia)
        {
            return Ok(await _admin.ObtenerPorProvinciaAsync(idProvincia));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Canton canton)
        {
            await _admin.AgregarAsync(canton);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Canton canton)
        {
            await _admin.EditarAsync(canton);
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
