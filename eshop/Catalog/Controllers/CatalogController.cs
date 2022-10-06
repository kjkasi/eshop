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
        private readonly ICatalogItemRepository _itemRepo;
        private readonly ICatalogBrandRepository _brandRepo;

        public CatalogController(ICatalogItemRepository itemRepo, ICatalogBrandRepository brandRepo)
        {
            _itemRepo = itemRepo;
            _brandRepo = brandRepo;
        }

        [HttpGet]
        [Route("items")]
        public async Task<ActionResult> ItemsAsync()
        {
            var catalogItems = await _itemRepo.GetCatalogItems();

            return Ok(catalogItems);
        }

        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<ActionResult> ItemByIdAsync(int id)
        {
            var catalogItem = await _itemRepo.GetCatalogItemById(id);
            if (catalogItem != null)
            {
                return Ok(catalogItem);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("items")]
        public async Task<ActionResult> CreateItemAsync(CatalogItem catalogItem)
        {
            await _itemRepo.CreateUpdateCatalogItem(catalogItem);
            return CreatedAtAction(nameof(ItemByIdAsync), new { Id = catalogItem.Id }, catalogItem);
        }

        [HttpGet]
        [Route("brands")]
        public async Task<ActionResult> BrandsAsync()
        {
            var catalogBrands = await _brandRepo.GetCatalogBrands();
            return Ok(catalogBrands);
        }

        [HttpGet("brands/{id:int}", Name = "BrandByIdAsync")]
        //[Route("brands/{id:int}")]
        public async Task<ActionResult> BrandByIdAsync(int id)
        {
            var catalogBrand = await _brandRepo.GetCatalogBrandById(id);
            if (catalogBrand != null)
            {
                return Ok(catalogBrand);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("brands")]
        public async Task<ActionResult> CreateBrandAsync(CatalogBrand catalogBrand)
        {
            await _brandRepo.CreateCatalogBrand(catalogBrand);
            return CreatedAtRoute(nameof(BrandByIdAsync), new { Id = catalogBrand.Id }, null);
        }
    }
}
