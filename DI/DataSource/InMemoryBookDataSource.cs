using DI.Model;

namespace DI.DataSource
{
    public class InMemoryBookDataSource : IBookDataSource
    {
        IDictionary<string, Book> _bookInfo;

        public InMemoryBookDataSource()
        {
            _bookInfo = new Dictionary<string, Book>();
        }

        public void AddBookInfo(string bookID, string bookName)
        {
            _bookInfo.Add(bookID, new Book() { Name = bookName, Id = bookID, AvailableToRent = true });
        }

        public bool IsBookAvailableToRent(string bookID)
        {
            var validBookId = _bookInfo.TryGetValue(bookID, out Book book);
            return validBookId && book.AvailableToRent;
        }

        public void UpdateBookStatus(string bookID, bool availableToRent)
        {
            var matchingBook = _bookInfo.First(b => b.Key == bookID).Value;
            matchingBook.AvailableToRent = availableToRent;
        }
    }
}