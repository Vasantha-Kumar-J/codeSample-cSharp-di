using DI.Model;

namespace DI
{
    /// <summary>
    /// Represents Data source that maintains <see cref="Book"/>
    /// </summary>
    public interface IBookDataSource
    {
        /// <summary>
        /// Adds the new book info to the book collection
        /// </summary>
        /// <param name="bookID">ID of the new book</param>
        /// <param name="bookName">Name of the new book</param>
        void AddBookInfo(string bookID, string bookName);

        /// <summary>
        /// Checks if the book is available for rent.
        /// </summary>
        /// <param name="bookID">ID of the book to check.</param>
        /// <returns>True, if the book is available to rent.</returns>
        bool IsBookAvailableToRent(string bookID);

        /// <summary>
        /// Updates the status of the book.
        /// </summary>
        /// <param name="bookID">ID of the book to perform the update upon.</param>
        /// <param name="availableToRent">Status to be updated to</param>
        void UpdateBookStatus(string bookID, bool availableToRent);
        
    }
}