using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IParticipacionRepository
    {
        Task<Participacion?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Participacion>> ObtenerAsync();
        Task<IEnumerable<Participacion>> ObtenerPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<Participacion>> ObtenerPorActividadAsync(int idActividad);
        Task<bool> ExisteAsync(int idUsuario, int idActividad);
        Task AgregarAsync(Participacion participacion);
        Task ActualizarAsync(Participacion participacion);
    }
}
