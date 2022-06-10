using Microsoft.EntityFrameworkCore;
using WebApiAuthors.Controllers.entities;

namespace WebApiAuthors
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<book> books { get; set; }

    }
}
