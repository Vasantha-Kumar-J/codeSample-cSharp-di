using DI.Model;

using Microsoft.EntityFrameworkCore;

namespace DI.DataSource
{
    /// <summary>
    /// Sample Data source that uses DB Context and interacts with actual Database.
    /// Can be used in production.
    /// </summary>
    public class EFBookDataSource : IBookDataSource
    {
        private readonly MyDbContext _dbContext;

        public EFBookDataSource(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void AddBookInfo(string bookID, string bookName)
        {
            var book = new Book
            {
                Id = bookID,
                Name = bookName,
                AvailableToRent = true
            };
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public bool IsBookAvailableToRent(string bookID)
        {
            return _dbContext.Books.Any(b => b.Id == bookID && b.AvailableToRent);
        }

        /// <inheritdoc/>
        public void UpdateBookStatus(string bookID, bool availableToRent)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == bookID);
            if (book == null)
            {
                return;
            }
            book.AvailableToRent = availableToRent;
            _dbContext.SaveChanges();
        }
    }

    /// <summary>
    /// Sample DB Context.
    /// </summary>
    public class MyDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Note: Update the SQL Server connection string based on requirement before usage.
            optionsBuilder.UseSqlServer("Server=localhost;Database=myDatabase;Trusted_Connection=True;");
        }
    }
}