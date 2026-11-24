using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorCentrosEducativos : IAdministradorCentrosEducativos
    {
        private readonly ICentroEducativoRepository _centroEducativoRepository;

        public AdministradorCentrosEducativos(ICentroEducativoRepository centroEducativoRepository)
        {
            _centroEducativoRepository = centroEducativoRepository;
        }

        public async Task<CentroEducativo?> ObtenerPorIdAsync(int id)
        {
            return await _centroEducativoRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<CentroEducativo>> ObtenerAsync()
        {
            return await _centroEducativoRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<CentroEducativo>> ObtenerPorDireccionAsync(int idDireccion)
        {
            return await _centroEducativoRepository.ObtenerPorDireccionAsync(idDireccion);
        }

        public async Task<IEnumerable<CentroEducativo>> ObtenerActivosAsync()
        {
            return await _centroEducativoRepository.ObtenerActivosAsync();
        }

        public async Task<IEnumerable<CentroEducativo>> ObtenerInactivosAsync()
        {
            return await _centroEducativoRepository.ObtenerInactivosAsync();
        }

        public async Task AgregarAsync(CentroEducativo centroEducativo)
        {
            centroEducativo.Fecha_Registro_CentroEducativo = DateTime.Now;
            centroEducativo.Activo = true;
            await _centroEducativoRepository.AgregarAsync(centroEducativo);
        }

        public async Task EditarAsync(CentroEducativo centroEducativo)
        {
            var centroAModificar = await _centroEducativoRepository
                .ObtenerPorIdAsync(centroEducativo.IdCentroEducativo);

            if (centroAModificar != null)
            {
                centroAModificar.Nombre_CentroEducativo = centroEducativo.Nombre_CentroEducativo;
                centroAModificar.IdDireccion = centroEducativo.IdDireccion;
                await _centroEducativoRepository.ActualizarAsync(centroAModificar);
            }
        }

        public async Task ActivarAsync(int id)
        {
            await _centroEducativoRepository.ActivarAsync(id);
        }

        public async Task DesActivarAsync(int id)
        {
            await _centroEducativoRepository.DesActivarAsync(id);
        }
    }
}
