using Microsoft.AspNetCore.Mvc;
using MVCProject.DAL;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class FAQController : Controller
    {
        private readonly AppDbContext _context;

        public FAQController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<FAQ> faqs = _context.FAQs.ToList();
            return View(faqs);
        }
    }
}
