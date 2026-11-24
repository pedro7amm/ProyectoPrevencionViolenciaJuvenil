using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IAdministradorProvincias
    {
        Task<Provincia?> ObtenerPorIdAsync(int id);
        Task<Provincia?> ObtenerPorDescripcionAsync(string descripcion);
        Task<IEnumerable<Provincia>> ObtenerAsync();
        Task<IEnumerable<Provincia>> ObtenerActivosAsync();
        Task<IEnumerable<Provincia>> ObtenerInactivosAsync();
        Task AgregarAsync(Provincia provincia);
        Task EditarAsync(Provincia provincia);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}