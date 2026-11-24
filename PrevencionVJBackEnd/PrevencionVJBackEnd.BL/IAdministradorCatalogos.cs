using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IAdministradorCatalogos
    {
        Task<Catalogo?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Catalogo>> ObtenerAsync();
        Task<IEnumerable<Catalogo>> ObtenerPorTipoAsync(int idTipoCatalogo);
        Task<IEnumerable<Catalogo>> ObtenerActivosAsync();
        Task<IEnumerable<Catalogo>> ObtenerInactivosAsync();
        Task AgregarAsync(Catalogo catalogo);
        Task EditarAsync(Catalogo catalogo);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}
