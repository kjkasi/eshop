using Catalog.Models;
using Catalog.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
        //[ProducesResponseType(typeof(IEnumerable<CatalogItem>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ItemsAsync()
        {
            Console.WriteLine("--> GetCatalogItems()");
            var catalogItems = await _repository.GetCatalogItems();

            return Ok(catalogItems);
        }

        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<ActionResult> ItemByIdAsync(int id)
        {
            Console.WriteLine("--> GetCatalogItemById()");
            var catalogItem = await _repository.GetCatalogItemById(id);
            if (catalogItem != null)
            {
                return Ok(catalogItem);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("items")]
        public async Task<ActionResult> CreateProductAsync(CatalogItem catalogItem)
        {
            Console.WriteLine("--> CreateCatalogItem()");
            await _repository.CreateUpdateCatalogItem(catalogItem);
            return CreatedAtAction(nameof(ItemByIdAsync), new { Id = catalogItem.Id }, catalogItem);
        }
    }
}
