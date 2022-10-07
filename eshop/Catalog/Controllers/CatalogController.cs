using Catalog.Models;
using Catalog.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
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

        [HttpGet("items")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> ItemsAsync()
        {
            var catalogItems = await _itemRepo.GetCatalogItems();

            return Ok(catalogItems);
        }

        [HttpGet("items/{id:int}", Name = "ItemByIdAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CatalogItem))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ItemByIdAsync(int id)
        {
            var catalogItem = await _itemRepo.GetCatalogItemById(id);
            if (catalogItem != null)
            {
                return Ok(catalogItem);
            }
            return NotFound();
        }

        [HttpPost("items")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> CreateItemAsync(CatalogItem catalogItem)
        {
            await _itemRepo.CreateUpdateCatalogItem(catalogItem);
            return CreatedAtAction(nameof(ItemByIdAsync), new { Id = catalogItem.Id }, catalogItem);
        }

        [HttpGet("brands")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> BrandsAsync()
        {
            var catalogBrands = await _brandRepo.GetCatalogBrands();
            return Ok(catalogBrands);
        }

        [HttpGet("brands/{id:int}", Name = "BrandByIdAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> BrandByIdAsync(int id)
        {
            var catalogBrand = await _brandRepo.GetCatalogBrandById(id);
            if (catalogBrand != null)
            {
                return Ok(catalogBrand);
            }
            return NotFound();
        }

        [HttpPost("brands")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> CreateBrandAsync(CatalogBrand catalogBrand)
        {
            CatalogBrand brand = await _brandRepo.CreateCatalogBrand(catalogBrand);
            return CreatedAtRoute(nameof(BrandByIdAsync), new { Id = catalogBrand.Id }, brand);
        }
    }
}
