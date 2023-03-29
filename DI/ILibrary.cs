namespace DI
{
    /// <summary>
    /// Library
    /// </summary>
    public interface ILibrary
    {
        /// <summary>
        /// Adds new book to the Library
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="bookName"></param>
        void AddNewBook(string bookID, string bookName);

        /// <summary>
        /// Rent book from the library
        /// </summary>
        /// <param name="bookID">ID of the book to rent</param>
        /// <returns>True if the rent process is successful</returns>
        bool TryRentBook(string bookID);

        /// <summary>
        /// Submit the book back to the library
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        bool SubmitBook(string bookID);
    }
}