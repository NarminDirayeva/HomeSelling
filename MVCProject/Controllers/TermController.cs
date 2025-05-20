using Microsoft.AspNetCore.Mvc;
using MVCProject.DAL;
using MVCProject.Models;
using System.Runtime.CompilerServices;

namespace MVCProject.Controllers
{
    public class TermController : Controller
    {
        private readonly AppDbContext _context;
        public TermController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Term> terms = _context.Terms.ToList();
            return View(terms);
        }
        
    }
}
