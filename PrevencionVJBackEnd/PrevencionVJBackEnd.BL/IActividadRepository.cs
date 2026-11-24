using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IActividadRepository
    {
        Task<Actividad?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Actividad>> ObtenerAsync();
        Task<IEnumerable<Actividad>> ObtenerPorComunidadAsync(int idComunidad);
        Task<IEnumerable<Actividad>> ObtenerPorEstadoAsync(int idEstadoActividad);
        Task AgregarAsync(Actividad actividad);
        Task ActualizarAsync(Actividad actividad);
    }
}
