using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.BookOperations.Commands.UpdateBook;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.BookOperations.Command
{
    public class UpdateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
      

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
          
            _context = testFixture.Context;
          
        }


        [Fact]
        public void WhenAllReadyExistUpdateBookIdGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrenge
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId =0; 
             
            //Act & Assert(Çalıştırma - Doğrulama)
             FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Bulunamadı");
             
        }


        
          [Fact]
          public void WhenAllReadyExistBookIdGiven_Book_ShouldBeUpdated()
        {
            //Arrenge
             UpdateBookCommand command = new UpdateBookCommand(_context);
             command.BookId = 3;
             UpdateBookModel model = new UpdateBookModel
             {
                Title ="Hobbit",
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId =1,
                PageCount = 200,
                AuthorId =2,
                Status =true
            };
            command.Model =model;
             //Act
             FluentActions.Invoking(()=>command.Handle()).Invoke();

             // Assert
            var book = _context.Books.SingleOrDefault(x=>x.Id == 3);
            book.Should().NotBeNull();
            book.Title.Should().Be(model.Title);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);
            book.PageCount.Should().Be(model.PageCount);
            book.AuthorId.Should().Be(model.AuthorId);
            book.Status.Should().Be(model.Status);
        }
    }
}