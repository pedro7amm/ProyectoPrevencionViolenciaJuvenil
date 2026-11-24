using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioDistritosController : ControllerBase
    {
        private readonly IAdministradorDistritos _admin;

        public ServicioDistritosController(IAdministradorDistritos admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Distrito>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerActivos")]
        public async Task<ActionResult<IEnumerable<Distrito>>> ObtenerActivos()
        {
            return Ok(await _admin.ObtenerActivosAsync());
        }

        [HttpGet("ObtenerInactivos")]
        public async Task<ActionResult<IEnumerable<Distrito>>> ObtenerInactivos()
        {
            return Ok(await _admin.ObtenerInactivosAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Distrito>> ObtenerPorId(int id)
        {
            var distrito = await _admin.ObtenerPorIdAsync(id);
            if (distrito == null)
                return NotFound();
            return Ok(distrito);
        }

        [HttpGet("ObtenerPorCodigoPostal")]
        public async Task<ActionResult<Distrito>> ObtenerPorCodigoPostal(string codigoPostal)
        {
            var distrito = await _admin.ObtenerPorCodigoPostalAsync(codigoPostal);
            if (distrito == null)
                return NotFound();
            return Ok(distrito);
        }

        [HttpGet("ObtenerPorCanton")]
        public async Task<ActionResult<IEnumerable<Distrito>>> ObtenerPorCanton(int idCanton)
        {
            return Ok(await _admin.ObtenerPorCantonAsync(idCanton));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Distrito distrito)
        {
            await _admin.AgregarAsync(distrito);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Distrito distrito)
        {
            await _admin.EditarAsync(distrito);
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
