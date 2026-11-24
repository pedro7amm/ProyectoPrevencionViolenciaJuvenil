using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PrevencionVJContext _context;

        public UsuarioRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await ConsultaConRelaciones()
                .FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<Usuario?> ObtenerPorCedulaAsync(string cedula)
        {
            return await ConsultaConRelaciones()
                .FirstOrDefaultAsync(u => u.Cedula_Usuario.ToLower() == cedula.ToLower());
        }

        public async Task<IEnumerable<Usuario>> ObtenerAsync()
        {
            return await ConsultaConRelaciones().ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObtenerPorComunidadAsync(int idComunidad)
        {
            return await ConsultaConRelaciones()
                .Where(u => u.IdComunidad == idComunidad)
                .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObtenerPorTipoAsync(int idTipoUsuario)
        {
            return await ConsultaConRelaciones()
                .Where(u => u.IdTipoUsuario == idTipoUsuario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObtenerActivosAsync()
        {
            return await ConsultaConRelaciones()
                .Where(u => u.Activo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObtenerInactivosAsync()
        {
            return await ConsultaConRelaciones()
                .Where(u => !u.Activo)
                .ToListAsync();
        }

        public async Task AgregarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task ActivarAsync(int id)
        {
            var usuario = await ObtenerPorIdAsync(id);
            if (usuario != null)
            {
                usuario.Activo = true;
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarAsync(int id)
        {
            var usuario = await ObtenerPorIdAsync(id);
            if (usuario != null)
            {
                usuario.Activo = false;
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
            }
        }

        private IQueryable<Usuario> ConsultaConRelaciones()
        {
            return _context.Usuarios
                .Include(u => u.Genero)
                .Include(u => u.Comunidad)
                .Include(u => u.TipoUsuario);
        }
    }
}
