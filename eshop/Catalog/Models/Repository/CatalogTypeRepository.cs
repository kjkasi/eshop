using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Models.Repository
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly CatalogContext _context;

        public CatalogTypeRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<CatalogType> CreateCatalogType(CatalogType catalogType)
        {
            _context.CatalogTypes.Add(catalogType);

            await _context.SaveChangesAsync();
            return catalogType;
        }

        public async Task<bool> DeleteCatalogType(int typeId)
        {
            CatalogType catalogType = await _context.CatalogTypes.FirstOrDefaultAsync(u => u.Id == typeId);
            if (catalogType == null)
            {
                return false;
            }
            _context.CatalogTypes.Remove(catalogType);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CatalogType> GetCatalogTypeById(int typeId)
        {
            CatalogType catalogType = await _context.CatalogTypes.Where(x => x.Id == typeId).FirstOrDefaultAsync();
            return catalogType;
        }

        public async Task<IEnumerable<CatalogType>> GetCatalogTypes()
        {
            List<CatalogType> typeList = await _context.CatalogTypes.ToListAsync();
            return typeList;
        }

        public async Task<CatalogType> UpdateCatalogType(CatalogType catalogType)
        {
            _context.CatalogTypes.Update(catalogType);

            await _context.SaveChangesAsync();
            return catalogType;
        }
    }
}
