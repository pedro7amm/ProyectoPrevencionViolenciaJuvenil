using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class SeguimientoRepository : ISeguimientoRepository
    {
        private readonly PrevencionVJContext _context;

        public SeguimientoRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<Seguimiento?> ObtenerPorIdAsync(int id)
        {
            return await ConsultaConRelaciones()
                .FirstOrDefaultAsync(s => s.IdSeguimiento == id);
        }

        public async Task<IEnumerable<Seguimiento>> ObtenerAsync()
        {
            return await ConsultaConRelaciones().ToListAsync();
        }

        public async Task<IEnumerable<Seguimiento>> ObtenerPorEstudianteAsync(int idEstudiante)
        {
            return await ConsultaConRelaciones()
                .Where(s => s.IdEstudiante == idEstudiante)
                .ToListAsync();
        }

        public async Task<IEnumerable<Seguimiento>> ObtenerPorEncargadoAsync(int idEncargado)
        {
            return await ConsultaConRelaciones()
                .Where(s => s.IdEncargado == idEncargado)
                .ToListAsync();
        }

        public async Task AgregarAsync(Seguimiento seguimiento)
        {
            await _context.Seguimientos.AddAsync(seguimiento);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Seguimiento seguimiento)
        {
            _context.Seguimientos.Update(seguimiento);
            await _context.SaveChangesAsync();
        }

        private IQueryable<Seguimiento> ConsultaConRelaciones()
        {
            return _context.Seguimientos
                .Include(s => s.Encargado)
                .Include(s => s.Estudiante);
        }
    }
}
