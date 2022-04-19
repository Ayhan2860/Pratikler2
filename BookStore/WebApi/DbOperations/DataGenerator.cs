using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                 if (context.Books.Any() )
                 {
                     return;
                 }
                 context.Genres.AddRange(
                     new Genre {Name= "PersonalGrowth"},
                     new Genre {Name= "ScienceFiction",Status = false},
                     new Genre {Name= "Noval", Status = true}
                 );
                 context.Books.AddRange(
                     new Book { Title= "Heartland", GenreId=1,Status=false, PageCount = 224, AuthorId=1, PublishDate = new DateTime(2020,05,12)},
                     new Book { Title= "My Last Beautiful Paper Left",Status=true, GenreId=2, AuthorId=2, PageCount = 224, PublishDate = new DateTime(2021,05,12)},
                     new Book { Title= "Animal Farm", GenreId=3,Status=true, PageCount = 224, AuthorId=3, PublishDate = new DateTime(2018,05,12)},
                     new Book { Title= "Granger's Cabin", GenreId=2,Status=true, PageCount = 224, AuthorId=4, PublishDate = new DateTime(2015,05,12)}
                 );
                  context.Authors.AddRange(
                    new Author{FirstName = "LAUREN", LastName="BROOKE", DateOfBirth= new DateTime(1969,01,15)},
                    new Author{FirstName = "Marcel", LastName="Proust", DateOfBirth= new DateTime(1871,07,10)},
                    new Author{FirstName = "George", LastName="Orwell", DateOfBirth= new DateTime(1903,06,25)},
                    new Author{FirstName = "Richard Ellis", LastName="Shaw", DateOfBirth= new DateTime(1975,03,20)}
                     );

                 context.SaveChanges();
            }

            
        }
    }
}