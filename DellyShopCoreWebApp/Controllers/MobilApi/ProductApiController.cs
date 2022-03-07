using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellyShop.Domain.Models;
using DellyShop.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DellyShopCoreWebAppAdminPanel.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ILogger<ProductApiController> _logger;

        private RepositoryService _repo;

        public ProductApiController(ILogger<ProductApiController> logger, RepositoryService repo)
        {
            _logger = logger;
            _repo = repo;
        }

        // GET: api/<ProductApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductApiController>/5
        [HttpGet("GetProductList/{categoryId}")]
        public string GetProductList(int categoryId)
        {
            var list = _repo.Products.GetProducts(categoryId);


            return list.FirstOrDefault().Name;
        }

        // POST api/<ProductApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
