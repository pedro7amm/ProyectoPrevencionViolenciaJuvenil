using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorUsuariosCentrosEducativos : IAdministradorUsuariosCentrosEducativos
    {
        private readonly IUsuarioCentroEducativoRepository _usuarioCentroEducativoRepository;

        public AdministradorUsuariosCentrosEducativos(
            IUsuarioCentroEducativoRepository usuarioCentroEducativoRepository)
        {
            _usuarioCentroEducativoRepository = usuarioCentroEducativoRepository;
        }

        public async Task<UsuarioCentroEducativo?> ObtenerPorIdAsync(int id)
        {
            return await _usuarioCentroEducativoRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<UsuarioCentroEducativo>> ObtenerAsync()
        {
            return await _usuarioCentroEducativoRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<UsuarioCentroEducativo>> ObtenerPorUsuarioAsync(int idUsuario)
        {
            return await _usuarioCentroEducativoRepository.ObtenerPorUsuarioAsync(idUsuario);
        }

        public async Task<IEnumerable<UsuarioCentroEducativo>> ObtenerPorCentroEducativoAsync(
            int idCentroEducativo)
        {
            return await _usuarioCentroEducativoRepository
                .ObtenerPorCentroEducativoAsync(idCentroEducativo);
        }

        public async Task<IEnumerable<UsuarioCentroEducativo>> ObtenerActivosAsync()
        {
            return await _usuarioCentroEducativoRepository.ObtenerActivosAsync();
        }

        public async Task<IEnumerable<UsuarioCentroEducativo>> ObtenerInactivosAsync()
        {
            return await _usuarioCentroEducativoRepository.ObtenerInactivosAsync();
        }

        public async Task AgregarAsync(UsuarioCentroEducativo usuarioCentroEducativo)
        {
            usuarioCentroEducativo.EstudianteActivo = true;
            await _usuarioCentroEducativoRepository.AgregarAsync(usuarioCentroEducativo);
        }

        public async Task EditarAsync(UsuarioCentroEducativo usuarioCentroEducativo)
        {
            var registroAModificar = await _usuarioCentroEducativoRepository
                .ObtenerPorIdAsync(usuarioCentroEducativo.IdUsuarioCentroEducativo);

            if (registroAModificar != null)
            {
                registroAModificar.IdUsuario = usuarioCentroEducativo.IdUsuario;
                registroAModificar.IdCentroEducativo = usuarioCentroEducativo.IdCentroEducativo;
                await _usuarioCentroEducativoRepository.ActualizarAsync(registroAModificar);
            }
        }

        public async Task ActivarAsync(int id)
        {
            await _usuarioCentroEducativoRepository.ActivarAsync(id);
        }

        public async Task DesActivarAsync(int id)
        {
            await _usuarioCentroEducativoRepository.DesActivarAsync(id);
        }
    }
}
