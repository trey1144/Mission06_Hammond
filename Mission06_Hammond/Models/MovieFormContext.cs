using Microsoft.EntityFrameworkCore;

namespace Mission06_Hammond.Models
{
    public class MovieFormContext : DbContext // create a context class
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options) // constructor
        {

        }
        public DbSet<Form> Forms { get; set; } // create a DbSet property
    }
}
