using Microsoft.AspNetCore.Mvc;
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
        public ProductsController()
        {

        }

        [HttpGet("browse")]
        public IActionResult Browse()
        {
            // The Products View will be generated through Angular
            // see wwwroot/js/productsController.js
            return View();
        }

        [HttpGet("details")] // /{productCode}
        public IActionResult Details() // string productCode
        {
            // Get the specific product

            // Send product data to the view
            return View();
        }

    }
}
