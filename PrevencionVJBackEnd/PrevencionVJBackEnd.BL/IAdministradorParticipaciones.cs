using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IAdministradorParticipaciones
    {
        Task<Participacion?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Participacion>> ObtenerAsync();
        Task<IEnumerable<Participacion>> ObtenerPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<Participacion>> ObtenerPorActividadAsync(int idActividad);
        Task AgregarAsync(Participacion participacion);
        Task EditarAsync(Participacion participacion);
    }
}
