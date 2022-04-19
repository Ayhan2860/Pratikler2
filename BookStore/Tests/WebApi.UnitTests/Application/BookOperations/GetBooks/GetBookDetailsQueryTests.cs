
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
    public class GetBookDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailQueryTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
       public void WhenAllReadyExistBookIdGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrenge
            
            GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
            query.BookId = 0; 

            //Act & Assert(Çalıştırma - Doğrulama)
             FluentActions
            .Invoking(() => query.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap kaydı bulunamadı");
             
        }
        [Fact]
        public void WhenAllReadyExistBookIdGiven_Book_ShouldBeReturn()
        {
            //Arrenge
            
            GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
            query.BookId = 4;
            var result = query.Handle(); 

            //Act 
             FluentActions.Invoking(() => query.Handle()).Invoke();
            //Assert
            var book = _context.Books.SingleOrDefault(x=>x.Id ==4);
            var fullName = book.Author.FirstName +" " + book.Author.LastName;

            book.Should().NotBeNull();
            book.Title.Should().Be(result.Title);
            book.PublishDate.Should().Be(Convert.ToDateTime(result.PublishDate));
            book.PageCount.Should().Be(result.PageCount);
            fullName.Should().Be(result.FullName);
             
        }
        
    }
}


