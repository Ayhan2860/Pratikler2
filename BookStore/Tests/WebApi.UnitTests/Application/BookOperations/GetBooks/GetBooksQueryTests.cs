using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.BookOperations.Queries;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.BookOperations.GetBooks
{
    public class GetBooksQueryTests:IClassFixture<CommonTestFixture>
    {
         private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQueryTests(CommonTestFixture testFixture)
        {
            _mapper = testFixture.Mapper;
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenTheBookListIsCalled_InvalidOperationException_ShouldBeReturn()
        {
            //Arrenge
            var books = _context.Books.Include(x=>x.Author).Include(x=>x.Genre).Where(x=>x.Genre.Status == true).OrderBy(book=>book.Id).ToList<Book>();
            
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);

            //Act & Assert
            FluentActions.Invoking(() => query.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Hiçbir Kitap bulunamadı");
            
        }
    }
}