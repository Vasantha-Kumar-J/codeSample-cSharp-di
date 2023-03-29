using DI.Model;

namespace DI.DataSource
{
    /// <summary>
    /// Sample In memory data source that maintains book in a dictionary.
    /// </summary>
    public class InMemoryBookDataSource : IBookDataSource
    {
        IDictionary<string, Book> _bookInfo;

        public InMemoryBookDataSource()
        {
            _bookInfo = new Dictionary<string, Book>();
        }

        /// <inheritdoc/>
        public void AddBookInfo(string bookID, string bookName)
        {
            _bookInfo.Add(bookID, new Book() { Name = bookName, Id = bookID, AvailableToRent = true });
        }

        /// <inheritdoc/>
        public bool IsBookAvailableToRent(string bookID)
        {
            var validBookId = _bookInfo.TryGetValue(bookID, out Book book);
            return validBookId && book.AvailableToRent;
        }

        /// <inheritdoc/>
        public void UpdateBookStatus(string bookID, bool availableToRent)
        {
            var matchingBook = _bookInfo.First(b => b.Key == bookID).Value;
            matchingBook.AvailableToRent = availableToRent;
        }
    }
}