namespace MVCProject.Models
{
    public class ProductFeature
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }

        public int FeatureID { get; set; }
        public Feature? Feature { get; set; }
    }
}
