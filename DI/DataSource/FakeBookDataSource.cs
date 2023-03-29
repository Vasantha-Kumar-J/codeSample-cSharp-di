namespace DI.DataSource
{
    public class FakeBookDataSource : IBookDataSource
    {
        public void AddBookInfo(string bookID, string bookName)
        {
            // Do Nothing
        }

        // Always returns true
        public bool IsBookAvailableToRent(string bookID) => true;


        public void UpdateBookStatus(string bookID, bool availableToRent)
        {
            // Do Nothing
        }
    }
}