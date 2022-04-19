using System;
using System.Linq;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.DbOperations;
using WebApi.GenreOperations.Commands.DeleteCommand;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.GenreCommands
{
    public class DeleteGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteGenreCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenAllReadyExistDeleteGenreIdGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrenge
             DeleteGenreCommand command = new DeleteGenreCommand(_context);
             command.GenreId =0;

             //Act && Assert
             FluentActions.Invoking(()=>command.Handle())
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Sistemde Aranılan Tür Adı Bulunamadı");

        }
        [Fact]
        public void WhenAllReadyExistDeleteGenreIdGiven_Genre_ShouldBeDeleted()
        {
            //Arrenge
             DeleteGenreCommand command = new DeleteGenreCommand(_context);
             command.GenreId =1;
             
             //Act
             FluentActions.Invoking(()=>command.Handle()).Invoke();

             //Assert
             var genre = _context.Genres.SingleOrDefault(x=>x.Id ==1);
             genre.Should().BeNull();

        }
    }
}