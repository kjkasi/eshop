﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class CatalogType
    {
        public int Id { get; set; }

        public string Type { get; set; }
    }
}
