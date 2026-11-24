using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class CantonRepository : ICantonRepository
    {
        private readonly PrevencionVJContext _context;

        public CantonRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<Canton?> ObtenerPorIdAsync(int id)
        {
            return await _context.Cantones
                .Include(c => c.Provincia)
                .Include(c => c.Distritos)
                .FirstOrDefaultAsync(c => c.IdCanton == id);
        }

        public async Task<Canton?> ObtenerPorDescripcionAsync(string descripcion)
        {
            return await _context.Cantones
                .Include(c => c.Provincia)
                .FirstOrDefaultAsync(c => c.Descripcion_Canton.ToLower() == descripcion.ToLower());
        }

        public async Task<IEnumerable<Canton>> ObtenerAsync()
        {
            return await _context.Cantones
                .Include(c => c.Provincia)
                .ToListAsync();
        }

        public async Task<IEnumerable<Canton>> ObtenerPorProvinciaAsync(int idProvincia)
        {
            return await _context.Cantones
                .Where(c => c.IdProvincia == idProvincia)
                .Include(c => c.Provincia)
                .ToListAsync();
        }

        public async Task<IEnumerable<Canton>> ObtenerActivosAsync()
        {
            return await _context.Cantones
                .Where(c => c.Activo)
                .Include(c => c.Provincia)
                .ToListAsync();
        }

        public async Task<IEnumerable<Canton>> ObtenerInactivosAsync()
        {
            return await _context.Cantones
                .Where(c => !c.Activo)
                .Include(c => c.Provincia)
                .ToListAsync();
        }

        public async Task AgregarAsync(Canton canton)
        {
            await _context.Cantones.AddAsync(canton);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Canton canton)
        {
            _context.Cantones.Update(canton);
            await _context.SaveChangesAsync();
        }

        public async Task ActivarAsync(int id)
        {
            var canton = await ObtenerPorIdAsync(id);
            if (canton != null)
            {
                canton.Activo = true;
                _context.Cantones.Update(canton);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarAsync(int id)
        {
            var canton = await ObtenerPorIdAsync(id);
            if (canton != null)
            {
                canton.Activo = false;
                _context.Cantones.Update(canton);
                await _context.SaveChangesAsync();
            }
        }
    }
}
