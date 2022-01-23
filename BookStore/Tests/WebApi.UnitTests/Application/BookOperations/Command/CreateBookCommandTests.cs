using Xunit;
using Tests.WebApi.UnitTests.TestSetup;
using FluentAssertions;
using WebApi.DbOperations;
using AutoMapper;
using WebApi.Entities;
using WebApi.BookOperations.Commands.CreateBook;
using System;
using System.Linq;

namespace Tests.WebApi.UnitTests.Application.BookOperations.Command
{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _mapper = testFixture.Mapper;
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAllReadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrange (Hazırlık)
            var book = new Book{Title ="WhenAllReadyExixtBookTitleGiven_InvalidOperationException_ShouldBeReturn", 
            PageCount=100,PublishDate = new System.DateTime(1890,01,05), GenreId =1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel(){Title = book.Title};
            //Act & Assert(Çalıştırma - Doğrulama)
             FluentActions
             .Invoking(() => command.Handle())
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu Kitap Sistemde Zaten Kayıtlı");
        }

        [Fact]
        public void WhenValidInputAreGiven_Book_ShouldBeCreated()
        {
            //Arrenge
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            CreateBookModel model = new CreateBookModel
            {
                Title ="Hobbit",
                PageCount=1000,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId =1,
                AuthorId =1
            };
             command.Model = model;
            //Act
            FluentActions.Invoking(()=>command.Handle()).Invoke();

            //Assert
            var book = _context.Books.SingleOrDefault(x=>x.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);
            book.AuthorId.Should().Be(model.AuthorId);

        }

        
    }
}