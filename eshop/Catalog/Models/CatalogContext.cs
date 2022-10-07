using Catalog.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Catalog.Models
{
    public class CatalogContext : DbContext
    {
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> opt)
            : base(opt)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public CatalogContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region ApplyConfiguration
            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
            #endregion


            #region CatalogBrandSeed
            builder.Entity<CatalogBrand>().HasData(new CatalogBrand
            {
                Id = 1,
                Brand = "Azure"
            },
            new CatalogBrand
            {
                Id = 2,
                Brand = ".NET"
            },
            new CatalogBrand
            {
                Id = 3,
                Brand = "Visual Studio"
            },
            new CatalogBrand
            {
                Id = 4,
                Brand = "SQL Server"
            },
            new CatalogBrand
            {
                Id = 5,
                Brand = "Other"
            });
            #endregion


            #region CatalogType
            builder.Entity<CatalogType>().HasData(new CatalogType
            {
                Id = 1,
                Type = "Mug"
            });
            #endregion

            # region CatalogItem
            /*
            builder.Entity<CatalogItem>().HasData(
            new CatalogItem
            {
                Id = 1,
                CatalogTypeId = 1,
                CatalogBrandId = 1,
                AvailableStock = 100,
                Description = ".NET Bot Black Hoodie",
                Name = ".NET Bot Black Hoodie",
                Price = 19.5M,
                PictureFileName = "1.png"
            },
            new CatalogItem
            {
                Id = 2,
                CatalogTypeId = 1,
                CatalogBrandId = 1,
                AvailableStock = 100,
                Description = ".NET Black & White Mug",
                Name = ".NET Black & White Mug",
                Price = 8.50M,
                PictureFileName = "2.png"
            }, 
            new CatalogItem
            {
                Id = 3,
                CatalogTypeId = 2,
                CatalogBrandId = 5,
                AvailableStock = 100,
                Description = "Prism White T-Shirt",
                Name = "Prism White T-Shirt",
                Price = 12,
                PictureFileName = "3.png"
            });
            */
            #endregion
        }
    }
}
