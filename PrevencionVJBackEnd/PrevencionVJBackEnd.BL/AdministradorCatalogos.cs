using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorCatalogos : IAdministradorCatalogos
    {
        private readonly ICatalogoRepository _catalogoRepository;

        public AdministradorCatalogos(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }

        public async Task<Catalogo?> ObtenerPorIdAsync(int id)
        {
            return await _catalogoRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Catalogo>> ObtenerAsync()
        {
            return await _catalogoRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Catalogo>> ObtenerPorTipoAsync(int idTipoCatalogo)
        {
            return await _catalogoRepository.ObtenerPorTipoAsync(idTipoCatalogo);
        }

        public async Task<IEnumerable<Catalogo>> ObtenerActivosAsync()
        {
            return await _catalogoRepository.ObtenerActivosAsync();
        }

        public async Task<IEnumerable<Catalogo>> ObtenerInactivosAsync()
        {
            return await _catalogoRepository.ObtenerInactivosAsync();
        }

        public async Task AgregarAsync(Catalogo catalogo)
        {
            catalogo.Activo = true;
            await _catalogoRepository.AgregarAsync(catalogo);
        }

        public async Task EditarAsync(Catalogo catalogo)
        {
            var catalogoAModificar = await _catalogoRepository.ObtenerPorIdAsync(catalogo.IdCatalogo);

            if (catalogoAModificar != null)
            {
                catalogoAModificar.Descripcion_Catalogo = catalogo.Descripcion_Catalogo;
                catalogoAModificar.IdTipoCatalogo = catalogo.IdTipoCatalogo;
                await _catalogoRepository.ActualizarAsync(catalogoAModificar);
            }
        }

        public async Task ActivarAsync(int id)
        {
            await _catalogoRepository.ActivarAsync(id);
        }

        public async Task DesActivarAsync(int id)
        {
            await _catalogoRepository.DesActivarAsync(id);
        }
    }
}
