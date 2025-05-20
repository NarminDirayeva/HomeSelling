namespace MVCProject.Models
{
    public class Dealer
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public List<Product>? Products { get; set; }
    }
}
