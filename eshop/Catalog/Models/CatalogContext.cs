using Microsoft.EntityFrameworkCore;

namespace Catalog.Models
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> opt)
            : base(opt)
        {
        }
    }
}
