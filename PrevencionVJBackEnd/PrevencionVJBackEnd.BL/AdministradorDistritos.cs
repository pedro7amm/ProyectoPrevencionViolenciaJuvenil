using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorDistritos : IAdministradorDistritos
    {
        private readonly IDistritoRepository _distritoRepository;

        public AdministradorDistritos(IDistritoRepository distritoRepository)
        {
            _distritoRepository = distritoRepository;
        }

        public async Task<Distrito?> ObtenerPorIdAsync(int id)
        {
            return await _distritoRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Distrito?> ObtenerPorCodigoPostalAsync(string codigoPostal)
        {
            return await _distritoRepository.ObtenerPorCodigoPostalAsync(codigoPostal);
        }

        public async Task<IEnumerable<Distrito>> ObtenerAsync()
        {
            return await _distritoRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Distrito>> ObtenerPorCantonAsync(int idCanton)
        {
            return await _distritoRepository.ObtenerPorCantonAsync(idCanton);
        }

        public async Task<IEnumerable<Distrito>> ObtenerActivosAsync()
        {
            return await _distritoRepository.ObtenerActivosAsync();
        }

        public async Task<IEnumerable<Distrito>> ObtenerInactivosAsync()
        {
            return await _distritoRepository.ObtenerInactivosAsync();
        }

        public async Task AgregarAsync(Distrito distrito)
        {
            distrito.Activo = true;
            await _distritoRepository.AgregarAsync(distrito);
        }

        public async Task EditarAsync(Distrito distrito)
        {
            var distritoAModificar = await _distritoRepository.ObtenerPorIdAsync(distrito.IdDistrito);

            if (distritoAModificar != null)
            {
                distritoAModificar.Descripcion_Distrito = distrito.Descripcion_Distrito;
                distritoAModificar.Codigo_Postal = distrito.Codigo_Postal;
                distritoAModificar.IdCanton = distrito.IdCanton;
                await _distritoRepository.ActualizarAsync(distritoAModificar);
            }
        }

        public async Task ActivarAsync(int id)
        {
            await _distritoRepository.ActivarAsync(id);
        }

        public async Task DesActivarAsync(int id)
        {
            await _distritoRepository.DesActivarAsync(id);
        }
    }
}
