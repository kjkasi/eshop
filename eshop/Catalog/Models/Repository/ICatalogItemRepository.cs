using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Models.Repository
{
    public interface ICatalogItemRepository
    {
        Task<IEnumerable<CatalogItem>> GetCatalogItems();
        Task<CatalogItem> GetCatalogItemById(int itemId);
        Task<CatalogItem> CreateCatalogItem(CatalogItem catalogItem);
        Task<CatalogItem> UpdateCatalogItem(CatalogItem catalogItem);
        Task<bool> DeleteCatalogItem(int itemId);
    }
}
