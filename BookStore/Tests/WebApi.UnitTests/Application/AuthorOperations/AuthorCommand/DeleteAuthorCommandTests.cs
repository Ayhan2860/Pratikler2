using System;
using System.Linq;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.AuthorOperations.Commands.DeleteAuthor;
using WebApi.DbOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.AuthorOperations.AuthorCommand
{
    public class DeleteAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteAuthorCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }
        
        [Fact]
        public void WhenAllReadyExistDeleteAuthorIdGivenAndWhenAuthorIsNull_InvalidOperationException_ShouldBeReturn()
        {
             //Arrenge
             DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
             command.AuthorId = 100;
             // Act
              Action act = () => command.Handle();
              //Assert
              act.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
        }

        [Fact]
        public void WhenAllReadyExistDeleteAuthorIdGivenAndWhenTheAuthorBookIsFound_InvalidOperationException_ShouldBeReturn()
        {
             //Arrenge
             DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
             command.AuthorId = 1;
             // Act
              Action act = () => command.Handle();
              //Assert
              act.Should().Throw<InvalidOperationException>()
              .Where(e=> e.Message == "Yazarın Yayında Olan Kitap'ı Mevcut");
        }

        [Fact]
        public void WhenAllReadyExistDeleteAuthorIdGiven_DeleteBook_ShouldBeReturn()
        {
             //Arrenge
             DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
             command.AuthorId = 3;
             
             // Act
              FluentActions.Invoking(()=>command.Handle()).Invoke();
              //Assert
              var author = _context.Authors.SingleOrDefault(x=>x.AuthorId ==3);
              author.Should().BeNull();
               
        }
       
        
    
    }
}