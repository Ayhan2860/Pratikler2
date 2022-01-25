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


        
       
        [Fact]
        public void WhenAllReadyExistDeleteBookIdGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrenge
             DeleteBookCommand command = new DeleteBookCommand(_context);
             command.BookId = 0;
             //Act & Assert(Çalıştırma - Doğrulama)
             FluentActions
             .Invoking(() => command.Handle())
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kayıtlı Kitap Bulunamadı!");
             

        }
          [InlineData(1)]
          [Theory]
          public void WhenAllReadyExistBookIdGiven_Book_ShouldBeDeleted(int id)
        {
            //Arrenge
             DeleteBookCommand command = new DeleteBookCommand(_context);
             command.BookId = id;
             //Act && Assert
             FluentActions.Invoking(()=>command.Handle()).Invoke();

        }
    }
}