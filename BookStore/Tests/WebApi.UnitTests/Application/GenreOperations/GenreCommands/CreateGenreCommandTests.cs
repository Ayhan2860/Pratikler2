using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.GenreOperations.Commands.CreateCommand;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.GenreCommands
{
    public class CreateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public void WhenAllReadyExistGenreNameGiven_InvalidOperationException_ShouldBeReturn()
        {       
                //Arrenge
                var genre = new Genre{Name ="Korku"};
                _context.Genres.Add(genre);
                _context.SaveChanges();
                CreateGenreCommand command = new CreateGenreCommand(_context,_mapper);
                command.Model = new CreateGenreViewModel{ Name = genre.Name };
                
              //act and assert
              FluentActions
             .Invoking(() => command.Handle())
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu Tür Adı Sistemde Zaten Kayıtlı");

        }

        [Fact]
        public void WhenAllReadyExistGenreNameGiven_Genre_ShouldBeCreated()
        {       
                //Arrenge
            
                CreateGenreCommand command = new CreateGenreCommand(_context,_mapper);
                CreateGenreViewModel model = new CreateGenreViewModel{ Name = "Dram" };
                command.Model = model;
              //act 
              FluentActions.Invoking(() => command.Handle()).Invoke();
              
              //assert
              var genres = _context.Genres.SingleOrDefault(x=>x.Name == model.Name);
              genres.Should().NotBeNull();
        }
    }
}