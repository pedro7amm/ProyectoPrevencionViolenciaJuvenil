using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class ComunidadRepository : IComunidadRepository
    {
        private readonly PrevencionVJContext _context;

        public ComunidadRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<Comunidad?> ObtenerPorIdAsync(int id)
        {
            return await _context.Comunidades
                .Include(c => c.Direccion)
                .FirstOrDefaultAsync(c => c.IdComunidad == id);
        }

        public async Task<IEnumerable<Comunidad>> ObtenerAsync()
        {
            return await _context.Comunidades
                .Include(c => c.Direccion)
                .ToListAsync();
        }

        public async Task<IEnumerable<Comunidad>> ObtenerPorDireccionAsync(int idDireccion)
        {
            return await _context.Comunidades
                .Where(c => c.IdDireccion == idDireccion)
                .Include(c => c.Direccion)
                .ToListAsync();
        }

        public async Task AgregarAsync(Comunidad comunidad)
        {
            await _context.Comunidades.AddAsync(comunidad);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Comunidad comunidad)
        {
            _context.Comunidades.Update(comunidad);
            await _context.SaveChangesAsync();
        }
    }
}
