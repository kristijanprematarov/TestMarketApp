namespace TestMarket.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TestMarket.Services.Interfaces;
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _productService.GetProduct(id);

            if (product != null)
                return View(product);
            else
                return NotFound();
        }
    }
}
