using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IAdministradorUsuariosCentrosEducativos
    {
        Task<UsuarioCentroEducativo?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<UsuarioCentroEducativo>> ObtenerAsync();
        Task<IEnumerable<UsuarioCentroEducativo>> ObtenerPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<UsuarioCentroEducativo>> ObtenerPorCentroEducativoAsync(int idCentroEducativo);
        Task<IEnumerable<UsuarioCentroEducativo>> ObtenerActivosAsync();
        Task<IEnumerable<UsuarioCentroEducativo>> ObtenerInactivosAsync();
        Task AgregarAsync(UsuarioCentroEducativo usuarioCentroEducativo);
        Task EditarAsync(UsuarioCentroEducativo usuarioCentroEducativo);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}
