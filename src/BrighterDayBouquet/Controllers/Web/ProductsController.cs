using AutoMapper;
using BrighterDayBouquet.Data.Repositories;
using BrighterDayBouquet.Models;
using BrighterDayBouquet.ViewModels.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Controllers.Web
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private ILogger<ProductsController> _logger;
        private ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepo, ILogger<ProductsController> logger)
        {
            this._productRepository = productRepo;
            this._logger = logger;
        }

        [HttpGet("browse")]
        public IActionResult Browse()
        {
            try
            {
                var products = _productRepository.GetAll().OrderByDescending(p => p.Rating);
                return View(Mapper.Map<IEnumerable<ProductViewModel>>(products));
            }
            catch (Exception ex)
            {
                // In most cases, we're going to want to log errors as well as let users know
                // if they have done something wrong, and how they can avoid doing so in the future
                _logger.LogError($"Failed to get products from the database: {ex}");

                //TODO: Tell the user what went wrong, and how to fix.
            }

            return BadRequest("Error Occured.");
        }

        [HttpGet("details/{productCode}")]
        public IActionResult Details(string productCode)
        {
            try
            {
                var product = _productRepository.GetByProductCode(productCode);
                return View(Mapper.Map<ProductDetailsViewModel>(product));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to find specified product. CODE: {productCode} Details: {ex}");
            }

            return BadRequest("That product does not exist.");
        }
    }
}
