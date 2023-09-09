using Microsoft.EntityFrameworkCore;

namespace CRUD_EntityFramework_Movie.Models
{


public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }

    }
}