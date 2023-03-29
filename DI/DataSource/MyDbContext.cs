using DI.Model;

using Microsoft.EntityFrameworkCore;

namespace DI.DataSource
{
    public class MyDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=myDatabase;Trusted_Connection=True;");
        }
    }
}