using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface ICentroEducativoRepository
    {
        Task<CentroEducativo?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<CentroEducativo>> ObtenerAsync();
        Task<IEnumerable<CentroEducativo>> ObtenerPorDireccionAsync(int idDireccion);
        Task<IEnumerable<CentroEducativo>> ObtenerActivosAsync();
        Task<IEnumerable<CentroEducativo>> ObtenerInactivosAsync();
        Task AgregarAsync(CentroEducativo centroEducativo);
        Task ActualizarAsync(CentroEducativo centroEducativo);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}
