using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                 if (context.Books.Any())
                 {
                     return;
                 }
                 context.Books.AddRange(
                     new Book { Title= "Hearland", GenreId=1, PageCount = 224, PublishDate = new DateTime(2020,05,12)},
                     new Book { Title= "Marcel Proust", GenreId=2, PageCount = 224, PublishDate = new DateTime(2021,05,12)},
                     new Book { Title= "Dune", GenreId=3, PageCount = 224, PublishDate = new DateTime(2018,05,12)},
                     new Book { Title= "Lev Tolstoy", GenreId=2, PageCount = 224, PublishDate = new DateTime(2015,05,12)},
                    new Book { Title= "Lean Startup", GenreId=1, PageCount = 224, PublishDate = new DateTime(2019,05,12)}
                 );

                 context.SaveChanges();
            }
        }
    }
}