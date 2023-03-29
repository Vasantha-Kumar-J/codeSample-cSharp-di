using DI.DataSource;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DI.Test
{
    public class LibraryTests
    {
        private string _testBookID = "SOL1";
        private string _testBookName = "Around the world in 80 Days";
        private IHost _host;

        public LibraryTests()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.AddTransient<IBookDataSource, InMemoryBookDataSource>();
                    services.AddTransient<Library>();
                })
                .Build();
        }

        [Fact]
        public void EmptyLibrary_AddNewBook_BookAvailbleForRent()
        {
            var library = _host.Services.GetService<Library>();

            library.AddNewBook(_testBookID, _testBookName);

            Assert.True(library.DataSource.IsBookAvailableToRent(_testBookID));
        }

        [Fact]
        public void LibraryWithBook_RentBook_BookNotAvailbleForRent()
        {
            var library = _host.Services.GetService<Library>();
            library.AddNewBook(_testBookID, _testBookName);

            library.TryRentBook(_testBookID);

            Assert.False(library.DataSource.IsBookAvailableToRent(_testBookID));
        }

        [Fact]
        public void BookRented_SubmitBook_BookAvailbleForRent()
        {
            var library = _host.Services.GetService<Library>();
            library.AddNewBook(_testBookID, _testBookName);
            library.TryRentBook(_testBookID);

            library.SubmitBook(_testBookID);

            Assert.True(library.DataSource.IsBookAvailableToRent(_testBookID));
        }
    }
}