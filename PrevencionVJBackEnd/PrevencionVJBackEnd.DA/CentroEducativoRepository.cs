using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class CentroEducativoRepository : ICentroEducativoRepository
    {
        private readonly PrevencionVJContext _context;

        public CentroEducativoRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<CentroEducativo?> ObtenerPorIdAsync(int id)
        {
            return await _context.CentrosEducativos
                .Include(c => c.Direccion)
                .FirstOrDefaultAsync(c => c.IdCentroEducativo == id);
        }

        public async Task<IEnumerable<CentroEducativo>> ObtenerAsync()
        {
            return await _context.CentrosEducativos
                .Include(c => c.Direccion)
                .ToListAsync();
        }

        public async Task<IEnumerable<CentroEducativo>> ObtenerPorDireccionAsync(int idDireccion)
        {
            return await _context.CentrosEducativos
                .Where(c => c.IdDireccion == idDireccion)
                .Include(c => c.Direccion)
                .ToListAsync();
        }

        public async Task<IEnumerable<CentroEducativo>> ObtenerActivosAsync()
        {
            return await _context.CentrosEducativos
                .Where(c => c.Activo)
                .Include(c => c.Direccion)
                .ToListAsync();
        }

        public async Task<IEnumerable<CentroEducativo>> ObtenerInactivosAsync()
        {
            return await _context.CentrosEducativos
                .Where(c => !c.Activo)
                .Include(c => c.Direccion)
                .ToListAsync();
        }

        public async Task AgregarAsync(CentroEducativo centroEducativo)
        {
            await _context.CentrosEducativos.AddAsync(centroEducativo);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(CentroEducativo centroEducativo)
        {
            _context.CentrosEducativos.Update(centroEducativo);
            await _context.SaveChangesAsync();
        }

        public async Task ActivarAsync(int id)
        {
            var centroEducativo = await ObtenerPorIdAsync(id);
            if (centroEducativo != null)
            {
                centroEducativo.Activo = true;
                _context.CentrosEducativos.Update(centroEducativo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarAsync(int id)
        {
            var centroEducativo = await ObtenerPorIdAsync(id);
            if (centroEducativo != null)
            {
                centroEducativo.Activo = false;
                _context.CentrosEducativos.Update(centroEducativo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
