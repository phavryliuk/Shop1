
using Microsoft.EntityFrameworkCore;
using Shop1.Data.Models;


namespace Shop1.Data
{
    public class AppDbContent : DbContext
    {
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
        {

        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
