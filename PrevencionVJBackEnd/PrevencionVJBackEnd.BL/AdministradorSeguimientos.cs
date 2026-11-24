using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorSeguimientos : IAdministradorSeguimientos
    {
        private readonly ISeguimientoRepository _seguimientoRepository;

        public AdministradorSeguimientos(ISeguimientoRepository seguimientoRepository)
        {
            _seguimientoRepository = seguimientoRepository;
        }

        public async Task<Seguimiento?> ObtenerPorIdAsync(int id)
        {
            return await _seguimientoRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Seguimiento>> ObtenerAsync()
        {
            return await _seguimientoRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Seguimiento>> ObtenerPorEstudianteAsync(int idEstudiante)
        {
            return await _seguimientoRepository.ObtenerPorEstudianteAsync(idEstudiante);
        }

        public async Task<IEnumerable<Seguimiento>> ObtenerPorEncargadoAsync(int idEncargado)
        {
            return await _seguimientoRepository.ObtenerPorEncargadoAsync(idEncargado);
        }

        public async Task AgregarAsync(Seguimiento seguimiento)
        {
            seguimiento.Fecha_Seguimiento = DateTime.Now;
            await _seguimientoRepository.AgregarAsync(seguimiento);
        }

        public async Task EditarAsync(Seguimiento seguimiento)
        {
            var seguimientoAModificar = await _seguimientoRepository
                .ObtenerPorIdAsync(seguimiento.IdSeguimiento);

            if (seguimientoAModificar != null)
            {
                seguimientoAModificar.Asunto_Seguimiento = seguimiento.Asunto_Seguimiento;
                seguimientoAModificar.Descripcion_Seguimiento = seguimiento.Descripcion_Seguimiento;
                seguimientoAModificar.IdEncargado = seguimiento.IdEncargado;
                seguimientoAModificar.IdEstudiante = seguimiento.IdEstudiante;
                await _seguimientoRepository.ActualizarAsync(seguimientoAModificar);
            }
        }
    }
}
