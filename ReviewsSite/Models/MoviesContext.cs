using Microsoft.EntityFrameworkCore;
using System;

namespace ReviewsSite.Models
{
    public class MoviesContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewTag> ReviewTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasData(
                new Review()
                {
                    Id = 1,
                    Title = "Spiderman",
                    ImageUrl = "/images/spiderman.jpg",
                    ReviewCategory = "Action",
                    Content = "It was an ok movie, I guess.",
                    Date = new DateTime(2010, 10, 10)
                },
                new Review()
                {
                    Id = 2,
                    Title = "Batman",
                    ImageUrl = "/images/batman.jpg",
                    ReviewCategory = "Action",
                    Content = "It was great-ish",
                    Date = new DateTime(2009, 9, 9)
                },
                new Review()
                {
                    Id = 3,
                    Title = "X-Men",
                    ImageUrl = "/images/xmen.jpg",
                    ReviewCategory = "Action",
                    Content = "It was a awesome!",
                    Date = new DateTime(2008, 8, 8)
                }
                );

            modelBuilder.Entity<Tag>().HasData(
                new Tag() { Id = 1,  Text = "Action"},
                new Tag() { Id = 2,  Text = "Profanity"},
                new Tag() { Id = 3,  Text = "Kid-friendly"}
                );

            modelBuilder.Entity<ReviewTag>().HasData(
                new ReviewTag() { Id = 1, ReviewId = 1, TagId = 1 },
                new ReviewTag() { Id = 2, ReviewId = 1, TagId = 3 },
                new ReviewTag() { Id = 3, ReviewId = 2, TagId = 1 },
                new ReviewTag() { Id = 4, ReviewId = 2, TagId = 2 },
                new ReviewTag() { Id = 5, ReviewId = 3, TagId = 1 },
                new ReviewTag() { Id = 6, ReviewId = 3, TagId = 2 },
                new ReviewTag() { Id = 7, ReviewId = 3, TagId = 3 }
                );

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=KMReviews;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString)
                          .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
