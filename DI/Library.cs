using DI.DataSource;

namespace DI
{
    public class Library : ILibrary
    {
        // Not the best logic 😋 - Logic kept simple for brevity.

        public InMemoryBookDataSource DataSource { get;}

        public Library()
        {
            DataSource = new InMemoryBookDataSource();
        }

        public void AddNewBook(string bookID, string bookName)
        {
            DataSource.AddBookInfo(bookID, bookName);
        }

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