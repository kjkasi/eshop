using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Models.Repository
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly CatalogContext _context;

        public CatalogItemRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<CatalogItem> CreateUpdateCatalogItem(CatalogItem catalogItem)
        {
            if (catalogItem.Id > 0)
            {
                _context.CatalogItems.Update(catalogItem);
            }
            else
            {
                _context.CatalogItems.Add(catalogItem);
            }
            await _context.SaveChangesAsync();
            return catalogItem;
        }

        public async Task<bool> DeleteCatalogItem(int itemId)
        {
            CatalogItem catalogItem = await _context.CatalogItems.FirstOrDefaultAsync(u => u.Id == itemId);
            if (catalogItem == null)
            {
                return false;
            }
            _context.CatalogItems.Remove(catalogItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CatalogItem> GetCatalogItemById(int itemId)
        {
            CatalogItem catalogItem = await _context.CatalogItems.Where(x => x.Id == itemId).FirstOrDefaultAsync();
            return catalogItem;
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            List<CatalogItem> itemList = await _context.CatalogItems
                .Include(c => c.CatalogBrand)
                .Include(c => c.CatalogType)
                .ToListAsync();
            return itemList;
        }
    }
}
