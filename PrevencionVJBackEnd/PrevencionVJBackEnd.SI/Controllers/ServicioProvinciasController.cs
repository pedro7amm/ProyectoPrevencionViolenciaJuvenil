using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioProvinciasController : ControllerBase
    {
        private readonly IAdministradorProvincias _admin;

        public ServicioProvinciasController(IAdministradorProvincias admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Provincia>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerActivos")]
        public async Task<ActionResult<IEnumerable<Provincia>>> ObtenerActivos()
        {
            return Ok(await _admin.ObtenerActivosAsync());
        }

        [HttpGet("ObtenerInactivos")]
        public async Task<ActionResult<IEnumerable<Provincia>>> ObtenerInactivos()
        {
            return Ok(await _admin.ObtenerInactivosAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Provincia>> ObtenerPorId(int id)
        {
            var provincia = await _admin.ObtenerPorIdAsync(id);
            if (provincia == null)
                return NotFound();
            return Ok(provincia);
        }

        [HttpGet("ObtenerPorDescripcion")]
        public async Task<ActionResult<Provincia>> ObtenerPorDescripcion(string descripcion)
        {
            var provincia = await _admin.ObtenerPorDescripcionAsync(descripcion);
            if (provincia == null)
                return NotFound();
            return Ok(provincia);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Provincia provincia)
        {
            await _admin.AgregarAsync(provincia);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Provincia provincia)
        {
            await _admin.EditarAsync(provincia);
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
