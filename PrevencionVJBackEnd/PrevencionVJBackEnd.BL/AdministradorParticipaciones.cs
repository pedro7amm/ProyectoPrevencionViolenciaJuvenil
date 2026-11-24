using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorParticipaciones : IAdministradorParticipaciones
    {
        private readonly IParticipacionRepository _participacionRepository;

        public AdministradorParticipaciones(IParticipacionRepository participacionRepository)
        {
            _participacionRepository = participacionRepository;
        }

        public async Task<Participacion?> ObtenerPorIdAsync(int id)
        {
            return await _participacionRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Participacion>> ObtenerAsync()
        {
            return await _participacionRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Participacion>> ObtenerPorUsuarioAsync(int idUsuario)
        {
            return await _participacionRepository.ObtenerPorUsuarioAsync(idUsuario);
        }

        public async Task<IEnumerable<Participacion>> ObtenerPorActividadAsync(int idActividad)
        {
            return await _participacionRepository.ObtenerPorActividadAsync(idActividad);
        }

        public async Task AgregarAsync(Participacion participacion)
        {
            var existe = await _participacionRepository
                .ExisteAsync(participacion.IdUsuario, participacion.IdActividad);

            if (existe)
                throw new InvalidOperationException("El usuario ya está inscrito en esta actividad.");

            participacion.Fecha_Inscripcion = DateTime.Now;
            participacion.Asistio = false;
            await _participacionRepository.AgregarAsync(participacion);
        }

        public async Task EditarAsync(Participacion participacion)
        {
            var participacionAModificar = await _participacionRepository
                .ObtenerPorIdAsync(participacion.IdParticipacion);

            if (participacionAModificar != null)
            {
                participacionAModificar.Asistio = participacion.Asistio;
                await _participacionRepository.ActualizarAsync(participacionAModificar);
            }
        }
    }
}
