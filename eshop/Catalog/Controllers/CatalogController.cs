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
        [HttpGet]
        public ActionResult<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            Console.WriteLine("--> GetCatalogItems()");
            return Ok();
        }
    }
}
