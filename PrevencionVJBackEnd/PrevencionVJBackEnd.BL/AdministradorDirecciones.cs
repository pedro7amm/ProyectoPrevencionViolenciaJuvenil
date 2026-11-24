using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorDirecciones : IAdministradorDirecciones
    {
        private readonly IDireccionRepository _direccionRepository;

        public AdministradorDirecciones(IDireccionRepository direccionRepository)
        {
            _direccionRepository = direccionRepository;
        }

        public async Task<Direccion?> ObtenerPorIdAsync(int id)
        {
            return await _direccionRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Direccion>> ObtenerAsync()
        {
            return await _direccionRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Direccion>> ObtenerPorDistritoAsync(int idDistrito)
        {
            return await _direccionRepository.ObtenerPorDistritoAsync(idDistrito);
        }

        public async Task<IEnumerable<Direccion>> ObtenerActivosAsync()
        {
            return await _direccionRepository.ObtenerActivosAsync();
        }

        public async Task<IEnumerable<Direccion>> ObtenerInactivosAsync()
        {
            return await _direccionRepository.ObtenerInactivosAsync();
        }

        public async Task AgregarAsync(Direccion direccion)
        {
            direccion.Activo = true;
            await _direccionRepository.AgregarAsync(direccion);
        }

        public async Task EditarAsync(Direccion direccion)
        {
            var direccionAModificar = await _direccionRepository.ObtenerPorIdAsync(direccion.IdDireccion);

            if (direccionAModificar != null)
            {
                direccionAModificar.Otras_Sennas = direccion.Otras_Sennas;
                direccionAModificar.IdTipoDireccion = direccion.IdTipoDireccion;
                direccionAModificar.IdDistrito = direccion.IdDistrito;
                await _direccionRepository.ActualizarAsync(direccionAModificar);
            }
        }

        public async Task ActivarAsync(int id)
        {
            await _direccionRepository.ActivarAsync(id);
        }

        public async Task DesActivarAsync(int id)
        {
            await _direccionRepository.DesActivarAsync(id);
        }
    }
}
