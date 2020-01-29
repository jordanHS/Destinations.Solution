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
                new Destination { DestinationId = 2, Country = "Germany", City = "Berlin", Rating = 10},
                new Destination { DestinationId = 3, Country = "Germany", City = "Frankfurt", Rating = 10},
                new Destination { DestinationId = 4, Country = "Estonia", City = "Talinn", Rating = 9}
            );

            builder.Entity<Review>()
                .HasData(
                new Review { ReviewId = 1, Author = "Jordan_Safford", Text = "Beautiful city with lots of cool old architecture", DestinationId = 1},
                new Review { ReviewId = 2, Author = "Dave_Smith", Text = "Cool modern city with a lot of history", DestinationId = 2},
                new Review { ReviewId = 3, Author = "Jordan_Safford", Text = "Best food ever!", DestinationId = 3},
                new Review { ReviewId = 4, Author = "Richard_Jones", Text = "Unique faerie tale like city with lots of castles", DestinationId = 4}
            );
        }
    }
}