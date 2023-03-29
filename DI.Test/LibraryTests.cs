using DI;
using DI.DataSource;

namespace DI.Test
{
    public class LibraryTests
    {
        private string _testBookID = "SOL1";
        private string _testBookName = "Around the world in 80 Days";

        [Fact]
        public void EmptyLibrary_AddNewBook_BookAvailbleForRent()
        {
            Library library = new Library();

            library.AddNewBook(_testBookID, _testBookName);

            Assert.True(library.DataSource.IsBookAvailableToRent(_testBookID));
        }

        [Fact]
        public void LibraryWithBook_RentBook_BookNotAvailbleForRent()
        {
            Library library = new Library();
            library.AddNewBook(_testBookID, _testBookName);

            library.TryRentBook(_testBookID);

            Assert.False(library.DataSource.IsBookAvailableToRent(_testBookID));
        }

        [Fact]
        public void BookRented_SubmitBook_BookAvailbleForRent()
        {
            Library library = new Library();
            library.AddNewBook(_testBookID, _testBookName);
            library.TryRentBook(_testBookID);

            library.SubmitBook(_testBookID);

            Assert.True(library.DataSource.IsBookAvailableToRent(_testBookID));
        }
    }
}