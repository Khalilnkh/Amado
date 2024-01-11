using Amado.DAL;
using Amado.ViewModels.Shops;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amado.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ShopVM shopVM = new ShopVM
            {
                Brands = await _context.Brands.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                Products = await _context.Products.ToListAsync()
            };

            return View(shopVM);
        }

        [HttpPost]
        public async Task<IActionResult> FilterProducts(int? selectedBrand, int? selectedCategory)
        {
            var filteredProducts = _context.Products.AsQueryable();

            if (selectedBrand.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.BrandID == selectedBrand);
            }

            if (selectedCategory.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.CategoryID == selectedCategory);
            }

            var result = await filteredProducts.ToListAsync();

            return PartialView("_FilteredProductPartial", result);
        }


    }


}
