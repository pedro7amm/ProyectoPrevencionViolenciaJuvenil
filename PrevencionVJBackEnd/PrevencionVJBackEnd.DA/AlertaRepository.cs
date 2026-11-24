using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly PrevencionVJContext _context;

        public AlertaRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<Alerta?> ObtenerPorIdAsync(int id)
        {
            return await ConsultaConRelaciones()
                .FirstOrDefaultAsync(a => a.IdAlerta == id);
        }

        public async Task<IEnumerable<Alerta>> ObtenerAsync()
        {
            return await ConsultaConRelaciones().ToListAsync();
        }

        public async Task<IEnumerable<Alerta>> ObtenerPorEstudianteAsync(int idEstudiante)
        {
            return await ConsultaConRelaciones()
                .Where(a => a.IdEstudiante == idEstudiante)
                .ToListAsync();
        }

        public async Task<IEnumerable<Alerta>> ObtenerPorEstadoAsync(int idEstadoAlerta)
        {
            return await ConsultaConRelaciones()
                .Where(a => a.IdEstadoAlerta == idEstadoAlerta)
                .ToListAsync();
        }

        public async Task AgregarAsync(Alerta alerta)
        {
            await _context.Alertas.AddAsync(alerta);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Alerta alerta)
        {
            _context.Alertas.Update(alerta);
            await _context.SaveChangesAsync();
        }

        private IQueryable<Alerta> ConsultaConRelaciones()
        {
            return _context.Alertas
                .Include(a => a.Estudiante)
                .Include(a => a.EncargadoCreacion)
                .Include(a => a.TipoAlerta)
                .Include(a => a.EstadoAlerta);
        }
    }
}
