using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IAdministradorDistritos
    {
        Task<Distrito?> ObtenerPorIdAsync(int id);
        Task<Distrito?> ObtenerPorCodigoPostalAsync(string codigoPostal);
        Task<IEnumerable<Distrito>> ObtenerAsync();
        Task<IEnumerable<Distrito>> ObtenerPorCantonAsync(int idCanton);
        Task<IEnumerable<Distrito>> ObtenerActivosAsync();
        Task<IEnumerable<Distrito>> ObtenerInactivosAsync();
        Task AgregarAsync(Distrito distrito);
        Task EditarAsync(Distrito distrito);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}
