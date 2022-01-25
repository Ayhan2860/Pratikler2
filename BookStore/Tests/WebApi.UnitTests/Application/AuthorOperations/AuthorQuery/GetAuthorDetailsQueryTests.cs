using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.AuthorOperations.Queries;
using WebApi.DbOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.AuthorOperations.AuthorQuery
{
    public class GetAuthorDetailsQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorDetailsQueryTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;

        }

        [Fact]
        public void WhenAllReadyExistAuthorIdGiven_InvalidOperationException_ShouldBeReturn()
        {
             //arrenge
             GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
             query.AuthorId =100;
             
             //act
             Action act = ()=>query.Handle();
             //Assert
             act.Should().Throw<InvalidOperationException>()
              .Where(e=> e.Message == "Yazar Bulunamadı");

        }

        [Fact]
        public void WhenAllReadyExistAuthorIdGiven_Author_ShouldBeReturn()
        {
             //arrenge
             GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
             query.AuthorId =4;
             var result = query.Handle();
             //act
             FluentActions.Invoking(()=>query.Handle());
             //Assert
            var author = _context.Authors.SingleOrDefault(x=>x.AuthorId ==1);
            author.Should().NotBeNull();
            author.FirstName.Should().Be(result.FirstName);
            author.LastName.Should().Be(result.LastName);
            author.DateOfBirth.Should().Be(result.DateOfBirth);

        }

    }
}