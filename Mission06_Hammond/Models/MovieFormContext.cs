using Microsoft.EntityFrameworkCore;

namespace Mission06_Hammond.Models
{
    public class MovieFormContext : DbContext // create a context class
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options) // constructor
        {

        }
        public DbSet<Movies> Movies { get; set; } // create a DbSet property

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //seed data
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 2, CategoryName = "Drama" },
                new Category { CategoryID = 3, CategoryName = "Television" },
                new Category { CategoryID = 4, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 5, CategoryName = "Comedy" },
                new Category { CategoryID = 6, CategoryName = "Family" },
                new Category { CategoryID = 7, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 8, CategoryName = "VHS" }
            );
        }
    }
}
