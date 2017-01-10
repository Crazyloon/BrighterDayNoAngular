using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Controllers.Web
{
    public class AppController : Controller
    {
        public AppController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            // The Products View will be generated through Angular
            // see wwwroot/js/productsController.js
            return View();
        }
    }
}
