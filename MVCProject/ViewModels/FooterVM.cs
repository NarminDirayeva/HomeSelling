using MVCProject.Models;

namespace MVCProject.ViewModels
{
    public class FooterVM
    {
        public Dictionary<string, string> Settings { get; set; }
        public List<Product> Products { get; set; }
    }
}
