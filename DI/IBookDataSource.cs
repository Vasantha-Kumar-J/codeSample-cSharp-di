namespace DI
{
    public interface IBookDataSource
    {
        void AddBookInfo(string bookID, string bookName);

        bool IsBookAvailableToRent(string bookID);

        void UpdateBookStatus(string bookID, bool availableToRent);
        
    }
}