using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Models.Repository
{
    public class CatalogBrandRepository : ICatalogBrandRepository
    {
        private readonly CatalogContext _context;

        public CatalogBrandRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<CatalogBrand> CreateUpdateCatalogBrand(CatalogBrand catalogBrand)
        {
            if (catalogBrand.Id > 0)
            {
                _context.CatalogBrands.Update(catalogBrand);
            }
            else
            {
                _context.CatalogBrands.Add(catalogBrand);
            }
            await _context.SaveChangesAsync();
            return catalogBrand;
        }

        public async Task<bool> DeleteCatalogBrand(int brandId)
        {
            CatalogBrand catalogBrand = await _context.CatalogBrands.FirstOrDefaultAsync(u => u.Id == brandId);
            if (catalogBrand == null)
            {
                return false;
            }
            _context.CatalogBrands.Remove(catalogBrand);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CatalogBrand> GetCatalogBrandById(int brandId)
        {
            CatalogBrand catalogBrand = await _context.CatalogBrands.Where(x => x.Id == brandId).FirstOrDefaultAsync();
            return catalogBrand;
        }

        public async Task<IEnumerable<CatalogBrand>> GetCatalogBrands()
        {
            List<CatalogBrand> brandList = await _context.CatalogBrands.ToListAsync();
            return brandList;
        }
    }
}
