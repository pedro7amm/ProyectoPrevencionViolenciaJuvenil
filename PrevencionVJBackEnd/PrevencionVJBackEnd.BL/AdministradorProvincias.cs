using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorProvincias : IAdministradorProvincias
    {
        private readonly IProvinciaRepository _provinciaRepository;

        public AdministradorProvincias(
            IProvinciaRepository provinciaRepository)
        {
            _provinciaRepository = provinciaRepository;
        }

        public async Task<Provincia?> ObtenerPorIdAsync(int id)
        {
            return await _provinciaRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Provincia?> ObtenerPorDescripcionAsync(
            string descripcion)
        {
            return await _provinciaRepository
                .ObtenerPorDescripcionAsync(descripcion);
        }

        public async Task<IEnumerable<Provincia>> ObtenerAsync()
        {
            return await _provinciaRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Provincia>> ObtenerActivosAsync()
        {
            return await _provinciaRepository.ObtenerActivosAsync();
        }

        public async Task<IEnumerable<Provincia>> ObtenerInactivosAsync()
        {
            return await _provinciaRepository.ObtenerInactivosAsync();
        }

        public async Task AgregarAsync(Provincia provincia)
        {
            provincia.Activo = true;
            await _provinciaRepository.AgregarAsync(provincia);
        }

        public async Task EditarAsync(Provincia provincia)
        {
            var provinciaAModificar = await _provinciaRepository
                .ObtenerPorIdAsync(provincia.IdProvincia);

            if (provinciaAModificar != null)
            {
                provinciaAModificar.Descripcion_Provincia =
                    provincia.Descripcion_Provincia;

                await _provinciaRepository
                    .ActualizarAsync(provinciaAModificar);
            }
        }

        public async Task ActivarAsync(int id)
        {
            await _provinciaRepository.ActivarAsync(id);
        }

        public async Task DesActivarAsync(int id)
        {
            await _provinciaRepository.DesActivarAsync(id);
        }
    }
}