using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly PrevencionVJContext _context;

        public CatalogoRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<Catalogo?> ObtenerPorIdAsync(int id)
        {
            return await _context.Catalogos
                .Include(c => c.TipoCatalogo)
                .FirstOrDefaultAsync(c => c.IdCatalogo == id);
        }

        public async Task<IEnumerable<Catalogo>> ObtenerAsync()
        {
            return await _context.Catalogos
                .Include(c => c.TipoCatalogo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Catalogo>> ObtenerPorTipoAsync(int idTipoCatalogo)
        {
            return await _context.Catalogos
                .Where(c => c.IdTipoCatalogo == idTipoCatalogo)
                .Include(c => c.TipoCatalogo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Catalogo>> ObtenerActivosAsync()
        {
            return await _context.Catalogos
                .Where(c => c.Activo)
                .Include(c => c.TipoCatalogo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Catalogo>> ObtenerInactivosAsync()
        {
            return await _context.Catalogos
                .Where(c => !c.Activo)
                .Include(c => c.TipoCatalogo)
                .ToListAsync();
        }

        public async Task AgregarAsync(Catalogo catalogo)
        {
            await _context.Catalogos.AddAsync(catalogo);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Catalogo catalogo)
        {
            _context.Catalogos.Update(catalogo);
            await _context.SaveChangesAsync();
        }

        public async Task ActivarAsync(int id)
        {
            var catalogo = await ObtenerPorIdAsync(id);
            if (catalogo != null)
            {
                catalogo.Activo = true;
                _context.Catalogos.Update(catalogo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarAsync(int id)
        {
            var catalogo = await ObtenerPorIdAsync(id);
            if (catalogo != null)
            {
                catalogo.Activo = false;
                _context.Catalogos.Update(catalogo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
