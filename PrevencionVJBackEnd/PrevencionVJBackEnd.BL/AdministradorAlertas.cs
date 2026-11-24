using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorAlertas : IAdministradorAlertas
    {
        private readonly IAlertaRepository _alertaRepository;

        public AdministradorAlertas(IAlertaRepository alertaRepository)
        {
            _alertaRepository = alertaRepository;
        }

        public async Task<Alerta?> ObtenerPorIdAsync(int id)
        {
            return await _alertaRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Alerta>> ObtenerAsync()
        {
            return await _alertaRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Alerta>> ObtenerPorEstudianteAsync(int idEstudiante)
        {
            return await _alertaRepository.ObtenerPorEstudianteAsync(idEstudiante);
        }

        public async Task<IEnumerable<Alerta>> ObtenerPorEstadoAsync(int idEstadoAlerta)
        {
            return await _alertaRepository.ObtenerPorEstadoAsync(idEstadoAlerta);
        }

        public async Task AgregarAsync(Alerta alerta)
        {
            alerta.Fecha_Alerta = DateTime.Now;
            await _alertaRepository.AgregarAsync(alerta);
        }

        public async Task EditarAsync(Alerta alerta)
        {
            var alertaAModificar = await _alertaRepository.ObtenerPorIdAsync(alerta.IdAlerta);

            if (alertaAModificar != null)
            {
                alertaAModificar.Asunto_Alerta = alerta.Asunto_Alerta;
                alertaAModificar.Descripcion_Alerta = alerta.Descripcion_Alerta;
                alertaAModificar.IdEstudiante = alerta.IdEstudiante;
                alertaAModificar.IdEncargadoCreacion = alerta.IdEncargadoCreacion;
                alertaAModificar.IdTipoAlerta = alerta.IdTipoAlerta;
                alertaAModificar.IdEstadoAlerta = alerta.IdEstadoAlerta;
                await _alertaRepository.ActualizarAsync(alertaAModificar);
            }
        }
    }
}
