using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IAdministradorComunidades
    {
        Task<Comunidad?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Comunidad>> ObtenerAsync();
        Task<IEnumerable<Comunidad>> ObtenerPorDireccionAsync(int idDireccion);
        Task AgregarAsync(Comunidad comunidad);
        Task EditarAsync(Comunidad comunidad);
    }
}
