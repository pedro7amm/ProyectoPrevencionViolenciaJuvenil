using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioTiposCatalogoController : ControllerBase
    {
        private readonly IAdministradorTiposCatalogo _admin;

        public ServicioTiposCatalogoController(IAdministradorTiposCatalogo admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<TipoCatalogo>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerActivos")]
        public async Task<ActionResult<IEnumerable<TipoCatalogo>>> ObtenerActivos()
        {
            return Ok(await _admin.ObtenerActivosAsync());
        }

        [HttpGet("ObtenerInactivos")]
        public async Task<ActionResult<IEnumerable<TipoCatalogo>>> ObtenerInactivos()
        {
            return Ok(await _admin.ObtenerInactivosAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<TipoCatalogo>> ObtenerPorId(int id)
        {
            var tipo = await _admin.ObtenerPorIdAsync(id);
            if (tipo == null)
                return NotFound();
            return Ok(tipo);
        }

        [HttpGet("ObtenerPorNombre")]
        public async Task<ActionResult<TipoCatalogo>> ObtenerPorNombre(string nombre)
        {
            var tipo = await _admin.ObtenerPorNombreAsync(nombre);
            if (tipo == null)
                return NotFound();
            return Ok(tipo);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] TipoCatalogo tipoCatalogo)
        {
            await _admin.AgregarAsync(tipoCatalogo);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] TipoCatalogo tipoCatalogo)
        {
            await _admin.EditarAsync(tipoCatalogo);
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
