using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController1 : Controller
    {
        private readonly IProductService _productService;

        public ProductsController1(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var CustomResponse = await _productService.GetProductsWithCategory();
            return View(CustomResponse.Data);
        }
    }
}
