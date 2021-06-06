namespace TestMarket.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using TestMarket.DTOs;
    using TestMarket.Services.Interfaces;

    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();

            var homeDTO = new HomeDTO
            {
                Products = products
            };

            return View(homeDTO);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
