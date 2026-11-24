using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        private readonly PrevencionVJContext _context;

        public ProvinciaRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<Provincia?> ObtenerPorIdAsync(int id)
        {
            return await _context.Provincias
                .Include(p => p.Cantones)
                .FirstOrDefaultAsync(p => p.IdProvincia == id);
        }

        public async Task<Provincia?> ObtenerPorDescripcionAsync(string descripcion)
        {
            return await _context.Provincias
                .Include(p => p.Cantones)
                .FirstOrDefaultAsync(p => p.Descripcion_Provincia.ToLower() == descripcion.ToLower());
        }

        public async Task<IEnumerable<Provincia>> ObtenerAsync()
        {
            return await _context.Provincias
                .Include(p => p.Cantones)
                .ToListAsync();
        }

        public async Task<IEnumerable<Provincia>> ObtenerActivosAsync()
        {
            return await _context.Provincias
                .Where(p => p.Activo)
                .Include(p => p.Cantones)
                .ToListAsync();
        }

        public async Task<IEnumerable<Provincia>> ObtenerInactivosAsync()
        {
            return await _context.Provincias
                .Where(p => !p.Activo)
                .Include(p => p.Cantones)
                .ToListAsync();
        }

        public async Task AgregarAsync(Provincia provincia)
        {
            await _context.Provincias.AddAsync(provincia);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Provincia provincia)
        {
            _context.Provincias.Update(provincia);
            await _context.SaveChangesAsync();
        }

        public async Task ActivarAsync(int id)
        {
            var provincia = await ObtenerPorIdAsync(id);
            if (provincia != null)
            {
                provincia.Activo = true;
                _context.Provincias.Update(provincia);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarAsync(int id)
        {
            var provincia = await ObtenerPorIdAsync(id);
            if (provincia != null)
            {
                provincia.Activo = false;
                _context.Provincias.Update(provincia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
