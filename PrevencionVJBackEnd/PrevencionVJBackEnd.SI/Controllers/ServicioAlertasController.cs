using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioAlertasController : ControllerBase
    {
        private readonly IAdministradorAlertas _admin;

        public ServicioAlertasController(IAdministradorAlertas admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Alerta>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Alerta>> ObtenerPorId(int id)
        {
            var alerta = await _admin.ObtenerPorIdAsync(id);
            if (alerta == null)
                return NotFound();
            return Ok(alerta);
        }

        [HttpGet("ObtenerPorEstudiante")]
        public async Task<ActionResult<IEnumerable<Alerta>>> ObtenerPorEstudiante(int idEstudiante)
        {
            return Ok(await _admin.ObtenerPorEstudianteAsync(idEstudiante));
        }

        [HttpGet("ObtenerPorEstado")]
        public async Task<ActionResult<IEnumerable<Alerta>>> ObtenerPorEstado(int idEstadoAlerta)
        {
            return Ok(await _admin.ObtenerPorEstadoAsync(idEstadoAlerta));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Alerta alerta)
        {
            await _admin.AgregarAsync(alerta);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Alerta alerta)
        {
            await _admin.EditarAsync(alerta);
            return Ok();
        }
    }
}
