using System;
using WebApi;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
            new Book { Title= "Heart", GenreId=1,Status=true, PageCount = 224, AuthorId=1, PublishDate = new DateTime(2020,05,12)},
            new Book { Title= "My Last Beautiful Paper Left",Status=true, GenreId=2, AuthorId=2, PageCount = 224, PublishDate = new DateTime(2021,05,12)},
            new Book { Title= "Animal Farm", GenreId=3,Status=false, PageCount = 224, AuthorId=3, PublishDate = new DateTime(2018,05,12)},
            new Book { Title= "Granger's Cabin", GenreId=2,Status=true, PageCount = 224, AuthorId=4, PublishDate = new DateTime(2015,05,12)}
           );
        }
    }
}