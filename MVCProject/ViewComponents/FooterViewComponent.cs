using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.DAL;
using MVCProject.ViewModels;

namespace MVCProject.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        
        private readonly AppDbContext _context;
       public FooterViewComponent(AppDbContext context)
        {
            _context = context;
           
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterVM model = new FooterVM
            {
                Settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value),
                Products = await _context.Products
                                 .Include(p => p.Images)
                                 .OrderByDescending(p => p.ID)
                                 .Take(3)
                                 .ToListAsync()
            };

            return View(model);
        }
    }
}
