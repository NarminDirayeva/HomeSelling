using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<AdditionalDetail> AdditionalDetails { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Term> Terms { get; set; }

    }
}
