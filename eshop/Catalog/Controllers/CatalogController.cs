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
        private readonly ICatalogTypeRepository _typeRepo;

        public CatalogController(ICatalogItemRepository itemRepo, ICatalogBrandRepository brandRepo, ICatalogTypeRepository typeRepo)
        {
            _itemRepo = itemRepo;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
        }


        #region Items API
        [HttpGet("items")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> ItemsAsync()
        {
            var catalogItems = await _itemRepo.GetCatalogItems();

            return Ok(catalogItems);
        }

        [HttpGet("items/{id:int}", Name = "ItemByIdAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
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
        #endregion

        #region BrandsAPI
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
        #endregion

        #region Types API
        [HttpGet("types")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> TypesAsync()
        {
            var typeBrands = await _typeRepo.GetCatalogTypes();
            return Ok(typeBrands);
        }

        [HttpGet("types/{id:int}", Name = "TypesByIdAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> TypesByIdAsync(int id)
        {
            var catalogType = await _typeRepo.GetCatalogTypeById(id);
            if (catalogType != null)
            {
                return Ok(catalogType);
            }
            return NotFound();
        }

        [HttpPost("types")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> CreateTypeAsync(CatalogType catalogType)
        {
            CatalogType type = await _typeRepo.CreateCatalogType(catalogType);
            return CreatedAtRoute(nameof(TypesByIdAsync), new { Id = catalogType.Id }, type);
        }
        #endregion
    }
}
