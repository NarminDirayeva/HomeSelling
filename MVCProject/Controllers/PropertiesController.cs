using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.DAL;
using MVCProject.Models;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly AppDbContext _context;
        public PropertiesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(PropertiesVM vm)
        {
            var query = _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductFeatures)
                    .ThenInclude(pf => pf.Feature)
                .Include(p => p.Dealer)
                .Include(p => p.Images)
                .AsQueryable();

           
            if (!string.IsNullOrEmpty(vm.City))
                query = query.Where(p => p.City == vm.City);

            if (!string.IsNullOrEmpty(vm.Status))
                query = query.Where(p => p.Status == vm.Status);

            
            if (vm.SelectedFeatures != null && vm.SelectedFeatures.Any())
                query = query.Where(p =>
                    p.ProductFeatures.Any(pf => vm.SelectedFeatures.Contains(pf.FeatureID)));

           
            var products = await query.ToListAsync();

            
            ViewBag.Cities = await _context.Products
                .Select(p => p.City)
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct()
                .ToListAsync();

            ViewBag.Statuses = await _context.Products
                .Select(p => p.Status)
                .Where(s => !string.IsNullOrEmpty(s))
                .Distinct()
                .ToListAsync();

            ViewBag.Features = await _context.Features.ToListAsync();

            return View(products);
        }


        [Route("properties/detail/{id}")]
        public async Task<IActionResult> Detail(int? id, PropertiesVM vm)
        {
            if (id == null || id < 1) return BadRequest();

           
            Product product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductFeatures)
                    .ThenInclude(pf => pf.Feature)
                .Include(p => p.Dealer)
                .Include(p => p.AdditionalDetails)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (product == null) return NotFound();

           
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(vm.City))
                query = query.Where(p => p.City == vm.City);

            if (!string.IsNullOrEmpty(vm.Status))
                query = query.Where(p => p.Status == vm.Status);

          
            if (vm.SelectedFeatures != null && vm.SelectedFeatures.Any())
                query = query.Where(p => p.ProductFeatures.Any(pf => vm.SelectedFeatures.Contains(pf.FeatureID)));

            List<Product> similarProducts = await query
                .Where(p => p.CategoryID == product.CategoryID && p.ID != product.ID)
                .Include(p => p.Images)
                .Take(4)
                .ToListAsync();

            
            DetailVM detailVM = new DetailVM
            {
                Product = product,
                Dealer = product.Dealer,
                AdditionalDetail = product.AdditionalDetails,
                Feature = product.ProductFeatures.Select(pf => pf.Feature).ToList(),
                SimilarProperties = similarProducts
            };

          
            ViewBag.Cities = await _context.Products
                .Select(p => p.City)
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct()
                .ToListAsync();

            ViewBag.Statuses = await _context.Products
                .Select(p => p.Status)
                .Where(s => !string.IsNullOrEmpty(s))
                .Distinct()
                .ToListAsync();

            ViewBag.Features = await _context.Features.ToListAsync();

            return View(detailVM);
        }

    }
}
