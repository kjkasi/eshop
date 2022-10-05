using Catalog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Catalog.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogItemRepository _repository;

        public CatalogController(ICatalogItemRepository repository)
        {
            Console.WriteLine("--> CatalogController()");
            _repository = repository;
        }

        [HttpGet]
        [Route("items")]
        public ActionResult<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            Console.WriteLine("--> GetCatalogItems()");
            var catalogItems = _repository.GetCatalogItems();
            return Ok(catalogItems);
        }

        [HttpGet]
        [Route("items/{id:int}")]
        public ActionResult<CatalogItem> GetCatalogItemById(int id)
        {
            Console.WriteLine("--> GetCatalogItemById()");
            var catalogItem = _repository.GetCatalogItemById(id);
            if (catalogItem != null)
            {
                return Ok(catalogItem);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("items")]
        public ActionResult<CatalogItem> CreateCatalogItem(CatalogItem catalogItem)
        {
            Console.WriteLine("--> CreateCatalogItem()");
            _repository.CreateUpdateCatalogItem(catalogItem);
            return CreatedAtRoute(nameof(GetCatalogItemById), new { Id = catalogItem.Id }, catalogItem);
        }
    }
}
