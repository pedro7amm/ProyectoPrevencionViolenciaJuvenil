using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioActividadesController : ControllerBase
    {
        private readonly IAdministradorActividades _admin;

        public ServicioActividadesController(IAdministradorActividades admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Actividad>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Actividad>> ObtenerPorId(int id)
        {
            var actividad = await _admin.ObtenerPorIdAsync(id);
            if (actividad == null)
                return NotFound();
            return Ok(actividad);
        }

        [HttpGet("ObtenerPorComunidad")]
        public async Task<ActionResult<IEnumerable<Actividad>>> ObtenerPorComunidad(int idComunidad)
        {
            return Ok(await _admin.ObtenerPorComunidadAsync(idComunidad));
        }

        [HttpGet("ObtenerPorEstado")]
        public async Task<ActionResult<IEnumerable<Actividad>>> ObtenerPorEstado(int idEstadoActividad)
        {
            return Ok(await _admin.ObtenerPorEstadoAsync(idEstadoActividad));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Actividad actividad)
        {
            await _admin.AgregarAsync(actividad);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Actividad actividad)
        {
            await _admin.EditarAsync(actividad);
            return Ok();
        }
    }
}
