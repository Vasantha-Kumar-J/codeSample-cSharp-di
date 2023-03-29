namespace DI.DataSource
{
    /// <summary>
    /// Fake data source that can be used in Autoamted Tests.
    /// </summary>
    public class FakeBookDataSource : IBookDataSource
    {
        /// <inheritdoc/>
        public void AddBookInfo(string bookID, string bookName)
        {
            // Do Nothing
        }

        /// <inheritdoc/>
        /// <remarks>Always returns true</remarks> 
        public bool IsBookAvailableToRent(string bookID) => true;

        /// <inheritdoc/>
        public void UpdateBookStatus(string bookID, bool availableToRent)
        {
            // Do Nothing
        }
    }
}