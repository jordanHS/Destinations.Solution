using Microsoft.EntityFrameworkCore;

namespace Destinations.Models
{
    public class DestinationsContext : DbContext
    {
        public DestinationsContext(DbContextOptions<DestinationsContext> options)
            : base(options)
        {
        }

        public DbSet<Destination> Destinations { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Destination>()
                .HasData(
                new Destination { DestinationId = 1, Country = "Czech Republic", City = "Prague", Rating = 10},
                new Destination { DestinationId = 2, Country = "Germany", City = "Berlin", Rating = 10 },
                new Destination { DestinationId = 3, Country = "Estonia", City = "Talinn", Rating = 9}
            );
        }
    }
}