using ArtShop.Data.Data.Configurations;
using ArtShop.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArtworkOrderModelConfiguration());
            builder.ApplyConfiguration(new ArtworkCategoryModelConfiguration());
            builder.ApplyConfiguration(new ReviewModelConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ArtworkOrder> ArtworksOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ArtworkCategory> ArtworksCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
