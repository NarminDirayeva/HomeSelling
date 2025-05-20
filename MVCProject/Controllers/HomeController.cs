using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.DAL;
using MVCProject.Models;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
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

         
            var products = await query.Take(7).ToListAsync();

          
            List<Testimonial> testimonials = await _context.Testimonials.ToListAsync();

            HomeVM homeVM = new HomeVM
            {
                Product = products,
                Testimonial = testimonials
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

            return View(homeVM);
        }

        [Route("home/detail/{id}")]
        public IActionResult Detail(int id)
        {
            return RedirectToAction("Detail", "Properties", new { id = id });
        }

    }
}
