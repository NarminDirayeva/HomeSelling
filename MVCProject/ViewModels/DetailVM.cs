using MVCProject.Models;

namespace MVCProject.ViewModels
{
    public class DetailVM
    {
        public Product? Product { get; set; }
        public Dealer? Dealer { get; set; }
        public List<AdditionalDetail>? AdditionalDetail { get; set; }
        public List<Feature>? Feature { get; set; }
        public List<Product>? SimilarProperties { get; set; }
        public List<Product>? Products { get; set; }
    }
}
