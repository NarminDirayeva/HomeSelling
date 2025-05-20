namespace MVCProject.Models
{
    public class Image
    {
        public int ID { get; set; }
        public string? Filename { get; set; }
        public int ProductID { get; set; }
        public  Product Product { get; set; }
    }
}
