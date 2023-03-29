using DI.Model;

namespace DI.DataSource
{
    public class EFBookDataSource : IBookDataSource
    {
        private readonly MyDbContext _dbContext;

        public EFBookDataSource(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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

        public bool IsBookAvailableToRent(string bookID)
        {
            return _dbContext.Books.Any(b => b.Id == bookID && b.AvailableToRent);
        }

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
}