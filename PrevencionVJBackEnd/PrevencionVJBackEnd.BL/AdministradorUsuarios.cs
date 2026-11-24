using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public class AdministradorUsuarios : IAdministradorUsuarios
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AdministradorUsuarios(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _usuarioRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Usuario?> ObtenerPorCedulaAsync(string cedula)
        {
            return await _usuarioRepository.ObtenerPorCedulaAsync(cedula);
        }

        public async Task<IEnumerable<Usuario>> ObtenerAsync()
        {
            return await _usuarioRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Usuario>> ObtenerPorComunidadAsync(int idComunidad)
        {
            return await _usuarioRepository.ObtenerPorComunidadAsync(idComunidad);
        }

        public async Task<IEnumerable<Usuario>> ObtenerPorTipoAsync(int idTipoUsuario)
        {
            return await _usuarioRepository.ObtenerPorTipoAsync(idTipoUsuario);
        }

        public async Task<IEnumerable<Usuario>> ObtenerActivosAsync()
        {
            return await _usuarioRepository.ObtenerActivosAsync();
        }

        public async Task<IEnumerable<Usuario>> ObtenerInactivosAsync()
        {
            return await _usuarioRepository.ObtenerInactivosAsync();
        }

        public async Task AgregarAsync(Usuario usuario)
        {
            usuario.Fecha_Registro_Usuario = DateTime.Now;
            usuario.Activo = true;
            await _usuarioRepository.AgregarAsync(usuario);
        }

        public async Task EditarAsync(Usuario usuario)
        {
            var usuarioAModificar = await _usuarioRepository.ObtenerPorIdAsync(usuario.IdUsuario);

            if (usuarioAModificar != null)
            {
                usuarioAModificar.Cedula_Usuario = usuario.Cedula_Usuario;
                usuarioAModificar.Nombre_Usuario = usuario.Nombre_Usuario;
                usuarioAModificar.Apellido1_Usuario = usuario.Apellido1_Usuario;
                usuarioAModificar.Apellido2_Usuario = usuario.Apellido2_Usuario;
                usuarioAModificar.Fecha_Nacimiento_Usuario = usuario.Fecha_Nacimiento_Usuario;
                usuarioAModificar.IdGenero = usuario.IdGenero;
                usuarioAModificar.IdComunidad = usuario.IdComunidad;
                usuarioAModificar.IdTipoUsuario = usuario.IdTipoUsuario;
                await _usuarioRepository.ActualizarAsync(usuarioAModificar);
            }
        }

        public async Task ActivarAsync(int id)
        {
            await _usuarioRepository.ActivarAsync(id);
        }

        public async Task DesActivarAsync(int id)
        {
            await _usuarioRepository.DesActivarAsync(id);
        }
    }
}
