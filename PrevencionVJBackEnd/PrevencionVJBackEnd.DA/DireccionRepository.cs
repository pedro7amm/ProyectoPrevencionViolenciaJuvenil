using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly PrevencionVJContext _context;

        public DireccionRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<Direccion?> ObtenerPorIdAsync(int id)
        {
            return await _context.Direcciones
                .Include(d => d.TipoDireccion)
                .Include(d => d.Distrito)
                .FirstOrDefaultAsync(d => d.IdDireccion == id);
        }

        public async Task<IEnumerable<Direccion>> ObtenerAsync()
        {
            return await _context.Direcciones
                .Include(d => d.TipoDireccion)
                .Include(d => d.Distrito)
                .ToListAsync();
        }

        public async Task<IEnumerable<Direccion>> ObtenerPorDistritoAsync(int idDistrito)
        {
            return await _context.Direcciones
                .Where(d => d.IdDistrito == idDistrito)
                .Include(d => d.TipoDireccion)
                .Include(d => d.Distrito)
                .ToListAsync();
        }

        public async Task<IEnumerable<Direccion>> ObtenerActivosAsync()
        {
            return await _context.Direcciones
                .Where(d => d.Activo)
                .Include(d => d.TipoDireccion)
                .Include(d => d.Distrito)
                .ToListAsync();
        }

        public async Task<IEnumerable<Direccion>> ObtenerInactivosAsync()
        {
            return await _context.Direcciones
                .Where(d => !d.Activo)
                .Include(d => d.TipoDireccion)
                .Include(d => d.Distrito)
                .ToListAsync();
        }

        public async Task AgregarAsync(Direccion direccion)
        {
            await _context.Direcciones.AddAsync(direccion);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Direccion direccion)
        {
            _context.Direcciones.Update(direccion);
            await _context.SaveChangesAsync();
        }

        public async Task ActivarAsync(int id)
        {
            var direccion = await ObtenerPorIdAsync(id);
            if (direccion != null)
            {
                direccion.Activo = true;
                _context.Direcciones.Update(direccion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarAsync(int id)
        {
            var direccion = await ObtenerPorIdAsync(id);
            if (direccion != null)
            {
                direccion.Activo = false;
                _context.Direcciones.Update(direccion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
