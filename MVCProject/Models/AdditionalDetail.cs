namespace MVCProject.Models
{
    public class AdditionalDetail
    {
        public int ID { get; set; }
        public string? Waterfront { get; set; }
        public string? BuiltIn { get; set; }
        public string? Parking { get; set; }
        public string? View { get; set; }
        public string? WaterfrontDescription { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
