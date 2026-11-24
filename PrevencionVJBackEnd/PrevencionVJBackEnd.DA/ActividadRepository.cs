using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly PrevencionVJContext _context;

        public ActividadRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<Actividad?> ObtenerPorIdAsync(int id)
        {
            return await ConsultaConRelaciones()
                .FirstOrDefaultAsync(a => a.IdActividad == id);
        }

        public async Task<IEnumerable<Actividad>> ObtenerAsync()
        {
            return await ConsultaConRelaciones().ToListAsync();
        }

        public async Task<IEnumerable<Actividad>> ObtenerPorComunidadAsync(int idComunidad)
        {
            return await ConsultaConRelaciones()
                .Where(a => a.IdComunidad == idComunidad)
                .ToListAsync();
        }

        public async Task<IEnumerable<Actividad>> ObtenerPorEstadoAsync(int idEstadoActividad)
        {
            return await ConsultaConRelaciones()
                .Where(a => a.IdEstadoActividad == idEstadoActividad)
                .ToListAsync();
        }

        public async Task AgregarAsync(Actividad actividad)
        {
            await _context.Actividades.AddAsync(actividad);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Actividad actividad)
        {
            _context.Actividades.Update(actividad);
            await _context.SaveChangesAsync();
        }

        private IQueryable<Actividad> ConsultaConRelaciones()
        {
            return _context.Actividades
                .Include(a => a.Comunidad)
                .Include(a => a.EstadoActividad)
                .Include(a => a.Direccion);
        }
    }
}
