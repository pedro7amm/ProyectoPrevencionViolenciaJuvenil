using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface ICantonRepository
    {
        Task<Canton?> ObtenerPorIdAsync(int id);
        Task<Canton?> ObtenerPorDescripcionAsync(string descripcion);
        Task<IEnumerable<Canton>> ObtenerAsync();
        Task<IEnumerable<Canton>> ObtenerPorProvinciaAsync(int idProvincia);
        Task<IEnumerable<Canton>> ObtenerActivosAsync();
        Task<IEnumerable<Canton>> ObtenerInactivosAsync();
        Task AgregarAsync(Canton canton);
        Task ActualizarAsync(Canton canton);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}