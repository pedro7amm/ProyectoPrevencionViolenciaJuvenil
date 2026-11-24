using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IDireccionRepository
    {
        Task<Direccion?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Direccion>> ObtenerAsync();
        Task<IEnumerable<Direccion>> ObtenerPorDistritoAsync(int idDistrito);
        Task<IEnumerable<Direccion>> ObtenerActivosAsync();
        Task<IEnumerable<Direccion>> ObtenerInactivosAsync();
        Task AgregarAsync(Direccion direccion);
        Task ActualizarAsync(Direccion direccion);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}
