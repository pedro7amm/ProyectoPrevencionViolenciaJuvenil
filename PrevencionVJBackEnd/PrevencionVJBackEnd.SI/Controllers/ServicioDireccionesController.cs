using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioDireccionesController : ControllerBase
    {
        private readonly IAdministradorDirecciones _admin;

        public ServicioDireccionesController(IAdministradorDirecciones admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Direccion>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerActivos")]
        public async Task<ActionResult<IEnumerable<Direccion>>> ObtenerActivos()
        {
            return Ok(await _admin.ObtenerActivosAsync());
        }

        [HttpGet("ObtenerInactivos")]
        public async Task<ActionResult<IEnumerable<Direccion>>> ObtenerInactivos()
        {
            return Ok(await _admin.ObtenerInactivosAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Direccion>> ObtenerPorId(int id)
        {
            var direccion = await _admin.ObtenerPorIdAsync(id);
            if (direccion == null)
                return NotFound();
            return Ok(direccion);
        }

        [HttpGet("ObtenerPorDistrito")]
        public async Task<ActionResult<IEnumerable<Direccion>>> ObtenerPorDistrito(int idDistrito)
        {
            return Ok(await _admin.ObtenerPorDistritoAsync(idDistrito));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Direccion direccion)
        {
            await _admin.AgregarAsync(direccion);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Direccion direccion)
        {
            await _admin.EditarAsync(direccion);
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
