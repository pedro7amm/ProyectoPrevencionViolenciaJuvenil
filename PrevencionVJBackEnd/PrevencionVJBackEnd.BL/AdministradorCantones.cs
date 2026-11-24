using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorCantones : IAdministradorCantones
    {
        private readonly ICantonRepository _cantonRepository;

        public AdministradorCantones(ICantonRepository cantonRepository)
        {
            _cantonRepository = cantonRepository;
        }

        public async Task<Canton?> ObtenerPorIdAsync(int id)
        {
            return await _cantonRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Canton?> ObtenerPorDescripcionAsync(string descripcion)
        {
            return await _cantonRepository.ObtenerPorDescripcionAsync(descripcion);
        }

        public async Task<IEnumerable<Canton>> ObtenerAsync()
        {
            return await _cantonRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Canton>> ObtenerPorProvinciaAsync(int idProvincia)
        {
            return await _cantonRepository.ObtenerPorProvinciaAsync(idProvincia);
        }

        public async Task<IEnumerable<Canton>> ObtenerActivosAsync()
        {
            return await _cantonRepository.ObtenerActivosAsync();
        }

        public async Task<IEnumerable<Canton>> ObtenerInactivosAsync()
        {
            return await _cantonRepository.ObtenerInactivosAsync();
        }

        public async Task AgregarAsync(Canton canton)
        {
            canton.Activo = true;
            await _cantonRepository.AgregarAsync(canton);
        }

        public async Task EditarAsync(Canton canton)
        {
            var cantonAModificar = await _cantonRepository.ObtenerPorIdAsync(canton.IdCanton);

            if (cantonAModificar != null)
            {
                cantonAModificar.Descripcion_Canton = canton.Descripcion_Canton;
                cantonAModificar.IdProvincia = canton.IdProvincia;
                await _cantonRepository.ActualizarAsync(cantonAModificar);
            }
        }

        public async Task ActivarAsync(int id)
        {
            await _cantonRepository.ActivarAsync(id);
        }

        public async Task DesActivarAsync(int id)
        {
            await _cantonRepository.DesActivarAsync(id);
        }
    }
}
