namespace DI.Model
{
    /// <summary>
    /// Sample book class
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Book ID, Unique to each book.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the book.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Status of the book. True if available to rent.
        /// </summary>
        public bool AvailableToRent { get; set; }
    }
}
