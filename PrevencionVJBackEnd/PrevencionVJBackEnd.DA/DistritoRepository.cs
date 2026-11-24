using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class DistritoRepository : IDistritoRepository
    {
        private readonly PrevencionVJContext _context;

        public DistritoRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<Distrito?> ObtenerPorIdAsync(int id)
        {
            return await _context.Distritos
                .Include(d => d.Canton)
                .FirstOrDefaultAsync(d => d.IdDistrito == id);
        }

        public async Task<Distrito?> ObtenerPorCodigoPostalAsync(string codigoPostal)
        {
            return await _context.Distritos
                .Include(d => d.Canton)
                .FirstOrDefaultAsync(d => d.Codigo_Postal.ToLower() == codigoPostal.ToLower());
        }

        public async Task<IEnumerable<Distrito>> ObtenerAsync()
        {
            return await _context.Distritos
                .Include(d => d.Canton)
                .ToListAsync();
        }

        public async Task<IEnumerable<Distrito>> ObtenerPorCantonAsync(int idCanton)
        {
            return await _context.Distritos
                .Where(d => d.IdCanton == idCanton)
                .Include(d => d.Canton)
                .ToListAsync();
        }

        public async Task<IEnumerable<Distrito>> ObtenerActivosAsync()
        {
            return await _context.Distritos
                .Where(d => d.Activo)
                .Include(d => d.Canton)
                .ToListAsync();
        }

        public async Task<IEnumerable<Distrito>> ObtenerInactivosAsync()
        {
            return await _context.Distritos
                .Where(d => !d.Activo)
                .Include(d => d.Canton)
                .ToListAsync();
        }

        public async Task AgregarAsync(Distrito distrito)
        {
            await _context.Distritos.AddAsync(distrito);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Distrito distrito)
        {
            _context.Distritos.Update(distrito);
            await _context.SaveChangesAsync();
        }

        public async Task ActivarAsync(int id)
        {
            var distrito = await ObtenerPorIdAsync(id);
            if (distrito != null)
            {
                distrito.Activo = true;
                _context.Distritos.Update(distrito);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarAsync(int id)
        {
            var distrito = await ObtenerPorIdAsync(id);
            if (distrito != null)
            {
                distrito.Activo = false;
                _context.Distritos.Update(distrito);
                await _context.SaveChangesAsync();
            }
        }
    }
}
