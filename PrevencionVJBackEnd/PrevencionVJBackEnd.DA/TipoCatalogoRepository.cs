using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class TipoCatalogoRepository : ITipoCatalogoRepository
    {
        private readonly PrevencionVJContext _context;

        public TipoCatalogoRepository(PrevencionVJContext context)
        {
            _context = context;
        }

        public async Task<TipoCatalogo?> ObtenerPorIdAsync(int id)
        {
            return await _context.TiposCatalogo
                .Include(t => t.Catalogos)
                .FirstOrDefaultAsync(t => t.IdTipoCatalogo == id);
        }

        public async Task<TipoCatalogo?> ObtenerPorNombreAsync(string nombre)
        {
            return await _context.TiposCatalogo
                .Include(t => t.Catalogos)
                .FirstOrDefaultAsync(t => t.Nombre_Catalogo.ToLower() == nombre.ToLower());
        }

        public async Task<IEnumerable<TipoCatalogo>> ObtenerAsync()
        {
            return await _context.TiposCatalogo
                .Include(t => t.Catalogos)
                .ToListAsync();
        }

        public async Task<IEnumerable<TipoCatalogo>> ObtenerActivosAsync()
        {
            return await _context.TiposCatalogo
                .Where(t => t.Activo)
                .Include(t => t.Catalogos)
                .ToListAsync();
        }

        public async Task<IEnumerable<TipoCatalogo>> ObtenerInactivosAsync()
        {
            return await _context.TiposCatalogo
                .Where(t => !t.Activo)
                .Include(t => t.Catalogos)
                .ToListAsync();
        }

        public async Task AgregarAsync(TipoCatalogo tipoCatalogo)
        {
            await _context.TiposCatalogo.AddAsync(tipoCatalogo);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(TipoCatalogo tipoCatalogo)
        {
            _context.TiposCatalogo.Update(tipoCatalogo);
            await _context.SaveChangesAsync();
        }

        public async Task ActivarAsync(int id)
        {
            var tipoCatalogo = await ObtenerPorIdAsync(id);
            if (tipoCatalogo != null)
            {
                tipoCatalogo.Activo = true;
                _context.TiposCatalogo.Update(tipoCatalogo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarAsync(int id)
        {
            var tipoCatalogo = await ObtenerPorIdAsync(id);
            if (tipoCatalogo != null)
            {
                tipoCatalogo.Activo = false;
                _context.TiposCatalogo.Update(tipoCatalogo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
