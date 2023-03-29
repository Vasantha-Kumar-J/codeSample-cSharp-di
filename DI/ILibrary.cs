namespace DI
{
    /// <summary>
    /// Represents Library
    /// </summary>
    public interface ILibrary
    {
        void AddNewBook(string bookID, string bookName);

        bool TryRentBook(string bookID);

        bool SubmitBook(string bookID);
    }
}