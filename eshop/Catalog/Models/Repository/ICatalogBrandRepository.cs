using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Models.Repository
{
    public interface ICatalogBrandRepository
    {
        Task<IEnumerable<CatalogBrand>> GetCatalogBrands();
        Task<CatalogBrand> GetCatalogBrandById(int brandId);
        Task<CatalogBrand> CreateCatalogBrand(CatalogBrand catalogBrand);
        Task<CatalogBrand> UpdateCatalogBrand(CatalogBrand catalogBrand);
        Task<bool> DeleteCatalogBrand(int brandId);
    }
}
