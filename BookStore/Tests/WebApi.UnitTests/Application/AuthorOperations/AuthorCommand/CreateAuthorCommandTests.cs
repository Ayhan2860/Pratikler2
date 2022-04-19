using System;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.AuthorOperations.Commands.CreateAuthor;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tests.WebApi.UnitTests.Application.AuthorOperations.AuthorCommand
{
    public class CreateAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenAllReadyExistAuthorFirstAndLastNameGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrenge
             var author = new Author{FirstName = "Ahmet", LastName="Karaman", DateOfBirth= new DateTime(1969,01,15)};
             _context.Authors.Add(author);
             _context.SaveChanges();

             CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
             command.Model = new CreateAuthorModel(){FirstName = author.FirstName, LastName = author.LastName};

             //act and assert
             FluentActions
             .Invoking(() => command.Handle())
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu Yazar Kayıtlı");

        }

        [Fact]
        public void WhenInputNameGiven_Author_ShouldBeCreated()
        {
            //arrenge
             CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
             CreateAuthorModel model = new CreateAuthorModel(){
                 FirstName = "Alican",
                 LastName="Aktoka",
                 DateOfBirth= new DateTime(1969,01,15)
             };
              command.Model = model;
             //act 
             FluentActions
             .Invoking(() => command.Handle()).Invoke();

             //assert
             var author = _context.Authors.SingleOrDefault(x=>x.FirstName == model.FirstName && x.LastName == model.LastName);
             author.Should().NotBeNull();
             author.DateOfBirth.Should().Be(model.DateOfBirth);


        }
        
    }
}