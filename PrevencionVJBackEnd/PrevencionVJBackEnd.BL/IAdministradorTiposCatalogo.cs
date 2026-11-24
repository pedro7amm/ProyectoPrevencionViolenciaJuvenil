using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IAdministradorTiposCatalogo
    {
        Task<TipoCatalogo?> ObtenerPorIdAsync(int id);
        Task<TipoCatalogo?> ObtenerPorNombreAsync(string nombre);
        Task<IEnumerable<TipoCatalogo>> ObtenerAsync();
        Task<IEnumerable<TipoCatalogo>> ObtenerActivosAsync();
        Task<IEnumerable<TipoCatalogo>> ObtenerInactivosAsync();
        Task AgregarAsync(TipoCatalogo tipoCatalogo);
        Task EditarAsync(TipoCatalogo tipoCatalogo);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}
