using AutoMapper;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.DbOperations;
using System.Linq;
using Xunit;
using WebApi.BookOperations.Commands.DeleteBook;
using FluentAssertions;
using System;

namespace Tests.WebApi.UnitTests.Application.BookOperations.Command
{
    public class DeleteBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        
        [InlineData(2)]
        [Theory]
        public void WhenAllReadyExistBookIdGiven_InvalidOperationException_ShouldBeReturn(int id)
        {
            //Arrenge
             DeleteBookCommand command = new DeleteBookCommand(_context);
             command.BookId = id;
             //Act & Assert(Çalıştırma - Doğrulama)
             FluentActions
             .Invoking(() => command.Handle())
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kayıtlı Kitap Bulunamadı!");
             

        }
          [InlineData(2)]
          [Theory]
          public void WhenAllReadyExistBookIdGiven_ValidOperationException_ShouldBeReturn(int id)
        {
            //Arrenge
             DeleteBookCommand command = new DeleteBookCommand(_context);
             command.BookId = id;
             //Act 
             FluentActions.Invoking(()=>command.Handle()).Invoke();

             // Assert
             var book = _context.Books.SingleOrDefault(x=>x.Id == id);
             book.Should().Be(book);
            
             

        }
    }
}