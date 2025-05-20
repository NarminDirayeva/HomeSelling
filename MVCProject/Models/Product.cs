namespace MVCProject.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal Area  { get; set; }
        public string? City { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public int? DealerID { get; set; }
        public Dealer? Dealer { get; set; }
        public List<ProductFeature>? ProductFeatures { get; set; }
        public List<AdditionalDetail>? AdditionalDetails { get; set; }
        public List<Image> Images { get; set; }
    }
}
