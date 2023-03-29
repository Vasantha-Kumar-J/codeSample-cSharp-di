namespace DI
{
    /// <summary>
    /// Sample Library Class
    /// </summary>
    /// <remarks>Not the best logic 😋 - Logic kept simple for brevity.</remarks>
    public class Library : ILibrary
    {
        /// <summary>
        /// Data Source associated with the library
        /// </summary>
        public IBookDataSource DataSource { get;}


        /// <summary>
        /// Create a instance of Library
        /// </summary>
        /// <param name="dataSource">Associated Data Source</param>
        public Library(IBookDataSource dataSource)
        {
            DataSource = dataSource;
        }

        /// <inheritdoc/>
        public void AddNewBook(string bookID, string bookName)
        {
            DataSource.AddBookInfo(bookID, bookName);
        }


        /// <inheritdoc/>
        public bool TryRentBook(string bookID)
        {
            var isAvailable = DataSource.IsBookAvailableToRent(bookID);
            if (isAvailable)
            {
                DataSource.UpdateBookStatus(bookID, availableToRent: false);
                return true;
            }
            return false;
        }

        /// <inheritdoc/>
        public bool SubmitBook(string bookID)
        {            
            try
            {
                DataSource.UpdateBookStatus(bookID, availableToRent: true);
                return true;
            }
            catch
            {
                return false;
            }            
        }
    }
}