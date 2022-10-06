using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class CatalogBrand
    {
        public int Id { get; set; }

        public string Brand { get; set; }
    }
}
