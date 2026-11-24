using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorComunidades : IAdministradorComunidades
    {
        private readonly IComunidadRepository _comunidadRepository;

        public AdministradorComunidades(IComunidadRepository comunidadRepository)
        {
            _comunidadRepository = comunidadRepository;
        }

        public async Task<Comunidad?> ObtenerPorIdAsync(int id)
        {
            return await _comunidadRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Comunidad>> ObtenerAsync()
        {
            return await _comunidadRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Comunidad>> ObtenerPorDireccionAsync(int idDireccion)
        {
            return await _comunidadRepository.ObtenerPorDireccionAsync(idDireccion);
        }

        public async Task AgregarAsync(Comunidad comunidad)
        {
            await _comunidadRepository.AgregarAsync(comunidad);
        }

        public async Task EditarAsync(Comunidad comunidad)
        {
            var comunidadAModificar = await _comunidadRepository.ObtenerPorIdAsync(comunidad.IdComunidad);

            if (comunidadAModificar != null)
            {
                comunidadAModificar.Nombre_Comunidad = comunidad.Nombre_Comunidad;
                comunidadAModificar.Descripcion_Comunidad = comunidad.Descripcion_Comunidad;
                comunidadAModificar.IdDireccion = comunidad.IdDireccion;
                await _comunidadRepository.ActualizarAsync(comunidadAModificar);
            }
        }
    }
}
