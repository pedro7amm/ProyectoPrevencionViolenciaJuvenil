using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioCatalogosController : ControllerBase
    {
        private readonly IAdministradorCatalogos _admin;

        public ServicioCatalogosController(IAdministradorCatalogos admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Catalogo>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerActivos")]
        public async Task<ActionResult<IEnumerable<Catalogo>>> ObtenerActivos()
        {
            return Ok(await _admin.ObtenerActivosAsync());
        }

        [HttpGet("ObtenerInactivos")]
        public async Task<ActionResult<IEnumerable<Catalogo>>> ObtenerInactivos()
        {
            return Ok(await _admin.ObtenerInactivosAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Catalogo>> ObtenerPorId(int id)
        {
            var catalogo = await _admin.ObtenerPorIdAsync(id);
            if (catalogo == null)
                return NotFound();
            return Ok(catalogo);
        }

        [HttpGet("ObtenerPorTipo")]
        public async Task<ActionResult<IEnumerable<Catalogo>>> ObtenerPorTipo(int idTipoCatalogo)
        {
            return Ok(await _admin.ObtenerPorTipoAsync(idTipoCatalogo));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Catalogo catalogo)
        {
            await _admin.AgregarAsync(catalogo);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Catalogo catalogo)
        {
            await _admin.EditarAsync(catalogo);
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
