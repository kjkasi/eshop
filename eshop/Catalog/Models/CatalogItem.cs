using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public string PictureUri { get; set; }

        public int? CatalogTypeId { get; set; }

        public virtual CatalogType CatalogType { get; set; }

        public int? CatalogBrandId { get; set; }

        public virtual CatalogBrand CatalogBrand { get; set; }

        public int AvailableStock { get; set; }
    }
}
