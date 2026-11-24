using Microsoft.AspNetCore.Mvc;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioSeguimientosController : ControllerBase
    {
        private readonly IAdministradorSeguimientos _admin;

        public ServicioSeguimientosController(IAdministradorSeguimientos admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Seguimiento>>> Obtener()
        {
            return Ok(await _admin.ObtenerAsync());
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Seguimiento>> ObtenerPorId(int id)
        {
            var seguimiento = await _admin.ObtenerPorIdAsync(id);
            if (seguimiento == null)
                return NotFound();
            return Ok(seguimiento);
        }

        [HttpGet("ObtenerPorEstudiante")]
        public async Task<ActionResult<IEnumerable<Seguimiento>>> ObtenerPorEstudiante(
            int idEstudiante)
        {
            return Ok(await _admin.ObtenerPorEstudianteAsync(idEstudiante));
        }

        [HttpGet("ObtenerPorEncargado")]
        public async Task<ActionResult<IEnumerable<Seguimiento>>> ObtenerPorEncargado(
            int idEncargado)
        {
            return Ok(await _admin.ObtenerPorEncargadoAsync(idEncargado));
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Seguimiento seguimiento)
        {
            await _admin.AgregarAsync(seguimiento);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Seguimiento seguimiento)
        {
            await _admin.EditarAsync(seguimiento);
            return Ok();
        }
    }
}
