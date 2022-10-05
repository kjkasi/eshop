using Microsoft.EntityFrameworkCore;

namespace Catalog.Models
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> opt)
            : base(opt)
        {
            Database.EnsureCreated();
        }


        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //CatalogBrand
            builder.Entity<CatalogBrand>().HasData(new CatalogBrand
            {
                Id = 1,
                Brand = "Azure"
            });
            //CatalogType
            builder.Entity<CatalogType>().HasData(new CatalogType
            {
                Id = 1,
                Type = "Mug"
            });
            //CatalogItem
            builder.Entity<CatalogItem>().HasData(new CatalogItem
            {
                Id = 1,
                CatalogTypeId = 1,
                CatalogBrandId = 1,
                AvailableStock = 100,
                Description = ".NET Bot Black Hoodie",
                Name = ".NET Bot Black Hoodie",
                Price = 19.5M,
                PictureFileName = "1.png"
            });
        }
    }
}
