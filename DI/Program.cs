using DI.DataSource;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DI
{
    /// <summary>
    /// Startup class.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Without DI Container:

            //string testBookID = "SOL1";
            //string testBookName = "Around the world in 80 Days";

            //var dataSource = new InMemoryBookDataSource();
            //var library = new Library(dataSource);

            //library.AddNewBook(testBookID, testBookName);

            //var availabilty = library.DataSource.IsBookAvailableToRent(testBookID);
            #endregion

            #region With DI Container:
            string testBookID = "SOL1";
            string testBookName = "Around the world in 80 Days";

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddTransient<IBookDataSource,InMemoryBookDataSource>();
                    services.AddSingleton<Library>();
                })
                .Build();            
            
            var library = host.Services.GetRequiredService<Library>();

            library.AddNewBook(testBookID, testBookName);

            var availabilty = library.DataSource.IsBookAvailableToRent(testBookID);
            #endregion
        }
    }
}