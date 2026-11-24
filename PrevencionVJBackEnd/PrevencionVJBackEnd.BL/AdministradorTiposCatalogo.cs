using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorTiposCatalogo : IAdministradorTiposCatalogo
    {
        private readonly ITipoCatalogoRepository _tipoCatalogoRepository;

        public AdministradorTiposCatalogo(ITipoCatalogoRepository tipoCatalogoRepository)
        {
            _tipoCatalogoRepository = tipoCatalogoRepository;
        }

        public async Task<TipoCatalogo?> ObtenerPorIdAsync(int id)
        {
            return await _tipoCatalogoRepository.ObtenerPorIdAsync(id);
        }

        public async Task<TipoCatalogo?> ObtenerPorNombreAsync(string nombre)
        {
            return await _tipoCatalogoRepository.ObtenerPorNombreAsync(nombre);
        }

        public async Task<IEnumerable<TipoCatalogo>> ObtenerAsync()
        {
            return await _tipoCatalogoRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<TipoCatalogo>> ObtenerActivosAsync()
        {
            return await _tipoCatalogoRepository.ObtenerActivosAsync();
        }

        public async Task<IEnumerable<TipoCatalogo>> ObtenerInactivosAsync()
        {
            return await _tipoCatalogoRepository.ObtenerInactivosAsync();
        }

        public async Task AgregarAsync(TipoCatalogo tipoCatalogo)
        {
            tipoCatalogo.Activo = true;
            await _tipoCatalogoRepository.AgregarAsync(tipoCatalogo);
        }

        public async Task EditarAsync(TipoCatalogo tipoCatalogo)
        {
            var tipoCatalogoAModificar = await _tipoCatalogoRepository
                .ObtenerPorIdAsync(tipoCatalogo.IdTipoCatalogo);

            if (tipoCatalogoAModificar != null)
            {
                tipoCatalogoAModificar.Nombre_Catalogo = tipoCatalogo.Nombre_Catalogo;
                await _tipoCatalogoRepository.ActualizarAsync(tipoCatalogoAModificar);
            }
        }

        public async Task ActivarAsync(int id)
        {
            await _tipoCatalogoRepository.ActivarAsync(id);
        }

        public async Task DesActivarAsync(int id)
        {
            await _tipoCatalogoRepository.DesActivarAsync(id);
        }
    }
}
