using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorActividades : IAdministradorActividades
    {
        private readonly IActividadRepository _actividadRepository;

        public AdministradorActividades(IActividadRepository actividadRepository)
        {
            _actividadRepository = actividadRepository;
        }

        public async Task<Actividad?> ObtenerPorIdAsync(int id)
        {
            return await _actividadRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Actividad>> ObtenerAsync()
        {
            return await _actividadRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Actividad>> ObtenerPorComunidadAsync(int idComunidad)
        {
            return await _actividadRepository.ObtenerPorComunidadAsync(idComunidad);
        }

        public async Task<IEnumerable<Actividad>> ObtenerPorEstadoAsync(int idEstadoActividad)
        {
            return await _actividadRepository.ObtenerPorEstadoAsync(idEstadoActividad);
        }

        public async Task AgregarAsync(Actividad actividad)
        {
            ValidarActividad(actividad);
            await _actividadRepository.AgregarAsync(actividad);
        }

        public async Task EditarAsync(Actividad actividad)
        {
            ValidarActividad(actividad);

            var actividadAModificar = await _actividadRepository.ObtenerPorIdAsync(actividad.IdActividad);

            if (actividadAModificar != null)
            {
                actividadAModificar.Nombre_Actividad = actividad.Nombre_Actividad;
                actividadAModificar.Descripcion_Actividad = actividad.Descripcion_Actividad;
                actividadAModificar.Fecha_Inicio_Actividad = actividad.Fecha_Inicio_Actividad;
                actividadAModificar.Fecha_Fin_Actividad = actividad.Fecha_Fin_Actividad;
                actividadAModificar.Cupo_Maximo_Actividad = actividad.Cupo_Maximo_Actividad;
                actividadAModificar.IdComunidad = actividad.IdComunidad;
                actividadAModificar.IdEstadoActividad = actividad.IdEstadoActividad;
                actividadAModificar.IdDireccion = actividad.IdDireccion;
                await _actividadRepository.ActualizarAsync(actividadAModificar);
            }
        }

        private static void ValidarActividad(Actividad actividad)
        {
            if (actividad.Fecha_Fin_Actividad <= actividad.Fecha_Inicio_Actividad)
                throw new ArgumentException("La fecha final debe ser mayor que la fecha inicial.");

            if (actividad.Cupo_Maximo_Actividad <= 0)
                throw new ArgumentException("El cupo máximo debe ser mayor que cero.");
        }
    }
}
