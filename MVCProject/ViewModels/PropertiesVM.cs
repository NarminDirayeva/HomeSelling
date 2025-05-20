using MVCProject.Models;

namespace MVCProject.ViewModels
{
    public class PropertiesVM
    {
        public string Keyword { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinArea { get; set; }
        public int? MaxArea { get; set; }
        public List<int> SelectedFeatures { get; set; } = new List<int>();
    }
}
