using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioCentrosEducativosController : ControllerBase
    {
        private readonly IAdministradorCentrosEducativos _admin;

        public ServicioCentrosEducativosController(IAdministradorCentrosEducativos admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<CentroEducativo>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerActivos")]
        public async Task<ActionResult<IEnumerable<CentroEducativo>>> ObtenerActivos()
        {
            return Ok(await _admin.ObtenerActivosAsync());
        }

        [HttpGet("ObtenerInactivos")]
        public async Task<ActionResult<IEnumerable<CentroEducativo>>> ObtenerInactivos()
        {
            return Ok(await _admin.ObtenerInactivosAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<CentroEducativo>> ObtenerPorId(int id)
        {
            var centro = await _admin.ObtenerPorIdAsync(id);
            if (centro == null)
                return NotFound();
            return Ok(centro);
        }

        [HttpGet("ObtenerPorDireccion")]
        public async Task<ActionResult<IEnumerable<CentroEducativo>>> ObtenerPorDireccion(
            int idDireccion)
        {
            return Ok(await _admin.ObtenerPorDireccionAsync(idDireccion));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] CentroEducativo centroEducativo)
        {
            await _admin.AgregarAsync(centroEducativo);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CentroEducativo centroEducativo)
        {
            await _admin.EditarAsync(centroEducativo);
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
