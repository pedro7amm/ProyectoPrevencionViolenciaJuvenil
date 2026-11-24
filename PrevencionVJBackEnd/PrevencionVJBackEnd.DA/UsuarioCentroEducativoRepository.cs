using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class UsuarioCentroEducativoRepository : IUsuarioCentroEducativoRepository
    {
        private readonly PrevencionVJContext _context;

        public UsuarioCentroEducativoRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<UsuarioCentroEducativo?> ObtenerPorIdAsync(int id)
        {
            return await ConsultaConRelaciones()
                .FirstOrDefaultAsync(uc => uc.IdUsuarioCentroEducativo == id);
        }

        public async Task<IEnumerable<UsuarioCentroEducativo>> ObtenerAsync()
        {
            return await ConsultaConRelaciones().ToListAsync();
        }

        public async Task<IEnumerable<UsuarioCentroEducativo>> ObtenerPorUsuarioAsync(int idUsuario)
        {
            return await ConsultaConRelaciones()
                .Where(uc => uc.IdUsuario == idUsuario)
                .ToListAsync();
        }

        public async Task<IEnumerable<UsuarioCentroEducativo>> ObtenerPorCentroEducativoAsync(
            int idCentroEducativo)
        {
            return await ConsultaConRelaciones()
                .Where(uc => uc.IdCentroEducativo == idCentroEducativo)
                .ToListAsync();
        }

        public async Task<IEnumerable<UsuarioCentroEducativo>> ObtenerActivosAsync()
        {
            return await ConsultaConRelaciones()
                .Where(uc => uc.EstudianteActivo)
                .ToListAsync();
        }

        public async Task<IEnumerable<UsuarioCentroEducativo>> ObtenerInactivosAsync()
        {
            return await ConsultaConRelaciones()
                .Where(uc => !uc.EstudianteActivo)
                .ToListAsync();
        }

        public async Task AgregarAsync(UsuarioCentroEducativo usuarioCentroEducativo)
        {
            await _context.UsuariosCentrosEducativos.AddAsync(usuarioCentroEducativo);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(UsuarioCentroEducativo usuarioCentroEducativo)
        {
            _context.UsuariosCentrosEducativos.Update(usuarioCentroEducativo);
            await _context.SaveChangesAsync();
        }

        public async Task ActivarAsync(int id)
        {
            var registro = await ObtenerPorIdAsync(id);
            if (registro != null)
            {
                registro.EstudianteActivo = true;
                _context.UsuariosCentrosEducativos.Update(registro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarAsync(int id)
        {
            var registro = await ObtenerPorIdAsync(id);
            if (registro != null)
            {
                registro.EstudianteActivo = false;
                _context.UsuariosCentrosEducativos.Update(registro);
                await _context.SaveChangesAsync();
            }
        }

        private IQueryable<UsuarioCentroEducativo> ConsultaConRelaciones()
        {
            return _context.UsuariosCentrosEducativos
                .Include(uc => uc.Usuario)
                .Include(uc => uc.CentroEducativo);
        }
    }
}
