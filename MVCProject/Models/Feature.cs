namespace MVCProject.Models
{
    public class Feature
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<ProductFeature>? ProductFeatures { get; set; }
    }
}
