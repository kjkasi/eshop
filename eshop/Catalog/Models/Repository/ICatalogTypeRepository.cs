using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Models.Repository
{
    public interface ICatalogTypeRepository
    {
        Task<IEnumerable<CatalogType>> GetCatalogTypes();
        Task<CatalogType> GetCatalogTypeById(int typeId);
        Task<CatalogType> CreateCatalogType(CatalogType catalogType);
        Task<CatalogType> UpdateCatalogTyoe(CatalogType catalogType);
        Task<bool> DeleteCatalogType(int typeId);
    }
}
