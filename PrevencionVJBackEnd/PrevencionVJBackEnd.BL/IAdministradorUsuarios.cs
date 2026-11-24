using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IAdministradorUsuarios
    {
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task<Usuario?> ObtenerPorCedulaAsync(string cedula);
        Task<IEnumerable<Usuario>> ObtenerAsync();
        Task<IEnumerable<Usuario>> ObtenerPorComunidadAsync(int idComunidad);
        Task<IEnumerable<Usuario>> ObtenerPorTipoAsync(int idTipoUsuario);
        Task<IEnumerable<Usuario>> ObtenerActivosAsync();
        Task<IEnumerable<Usuario>> ObtenerInactivosAsync();
        Task AgregarAsync(Usuario usuario);
        Task EditarAsync(Usuario usuario);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}
