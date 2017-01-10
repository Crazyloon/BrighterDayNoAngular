using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrighterDayBouquet.Data.Repositories;
using BrighterDayBouquet.Models;
using BrighterDayBouquet.ViewModels.Api;
using BrighterDayBouquet.Data.Contracts;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace BrighterDayBouquet.Controllers.Api
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private ILogger<ProductsController> _logger;
        private IRepository<Product> _productsRepo;

        public ProductsController(IRepository<Product> productsRepo, ILogger<ProductsController> logger)
        {
            _productsRepo = productsRepo;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var products = _productsRepo.GetAll().OrderByDescending(p => p.Rating);
                return Ok(Mapper.Map<IEnumerable<ProductViewModel>>(products));
            }
            catch (Exception ex)
            {
                // In most cases, we're going to want to log errors as well as let users know
                // if they have done something wrong, and how they can avoid doing so in the future
                _logger.LogError($"Failed to get products from the database: {ex}");

                return BadRequest("Error Occured");
            }
        }

        [HttpPost("")]
        // FromBody -> modelbind the data from body to the model
        public IActionResult Post([FromBody]ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                // TODO
                // Protect Post so only store owners can access it
                // Actually add products to the database.
                var newProduct = Mapper.Map<Product>(product);
                return Created($"api/products/{product.ProductName}", Mapper.Map<ProductViewModel>(newProduct));
            }

            return BadRequest("Bad Data");
        }

    }
}