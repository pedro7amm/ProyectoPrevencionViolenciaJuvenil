using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class ParticipacionRepository : IParticipacionRepository
    {
        private readonly PrevencionVJContext _context;

        public ParticipacionRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<Participacion?> ObtenerPorIdAsync(int id)
        {
            return await ConsultaConRelaciones()
                .FirstOrDefaultAsync(p => p.IdParticipacion == id);
        }

        public async Task<IEnumerable<Participacion>> ObtenerAsync()
        {
            return await ConsultaConRelaciones().ToListAsync();
        }

        public async Task<IEnumerable<Participacion>> ObtenerPorUsuarioAsync(int idUsuario)
        {
            return await ConsultaConRelaciones()
                .Where(p => p.IdUsuario == idUsuario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Participacion>> ObtenerPorActividadAsync(int idActividad)
        {
            return await ConsultaConRelaciones()
                .Where(p => p.IdActividad == idActividad)
                .ToListAsync();
        }

        public async Task<bool> ExisteAsync(int idUsuario, int idActividad)
        {
            return await _context.Participaciones
                .AnyAsync(p => p.IdUsuario == idUsuario && p.IdActividad == idActividad);
        }

        public async Task AgregarAsync(Participacion participacion)
        {
            await _context.Participaciones.AddAsync(participacion);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Participacion participacion)
        {
            _context.Participaciones.Update(participacion);
            await _context.SaveChangesAsync();
        }

        private IQueryable<Participacion> ConsultaConRelaciones()
        {
            return _context.Participaciones
                .Include(p => p.Usuario)
                .Include(p => p.Actividad);
        }
    }
}
