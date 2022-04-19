using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.DbOperations;
using WebApi.GenreOperations.Commands.UpdateCommand;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.GenreCommands
{
    public class UpdateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateGenreCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public void WhenAllReadyExistUpdateAuthorIdGiven_InvalidOperationException_ShouldBeReturn()
        {
              //Arrenge
             UpdateGenreCommand command = new UpdateGenreCommand(_context,_mapper);
             command.GenreId =0;
             //Act & Assert(Çalıştırma - Doğrulama)
             FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Tür Adı Bulunamadı");
        }

        [Fact]
          public void WhenAllReadyExistGenreIdGiven_Genre_ShouldBeUpdated()
        {
          //Arrenge
             UpdateGenreCommand command = new UpdateGenreCommand(_context,_mapper);
             command.GenreId =2;
             UpdateGenreViewModel model = new UpdateGenreViewModel
             {
                 Name = "Polisiye",
                 Status = true
             };
             command.Model =model;
             //Act
             FluentActions.Invoking(()=>command.Handle()).Invoke();
             var genre = _context.Genres.SingleOrDefault(x=>x.Id ==2);
             genre.Should().NotBeNull();
             genre.Name.Should().Be(model.Name);
             genre.Status.Should().Be(model.Status);
        }

    }
}