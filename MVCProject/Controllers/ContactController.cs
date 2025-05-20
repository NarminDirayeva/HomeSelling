using Microsoft.AspNetCore.Mvc;
using MVCProject.DAL;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Contact contact)
        {
            
            if (!ModelState.IsValid)
            {
                
                ViewBag.Error = "Please correct the errors and try again.";
                return View(contact); 
            }

            
            _context.Contacts.Add(contact);
            _context.SaveChanges();

            
            ViewBag.Message = "Message sent successfully";

            ModelState.Clear();

            return View(); 
        }
    }
}
