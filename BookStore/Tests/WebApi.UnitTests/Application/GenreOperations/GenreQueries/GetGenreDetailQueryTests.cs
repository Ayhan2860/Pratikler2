using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.DbOperations;
using WebApi.GenreOperations.Queries;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.GenreQuery
{
    public class  GetGenreDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailQueryTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
       public void WhenAllReadyExistGenreIdGiven_InvalidOperationException_ShouldBeReturn()
        {
               //Arrenge
               GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
               query.GenreId =0;

               //Act && Assert
               FluentActions.Invoking(()=>query.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Sistemde Kayıtlı Tür Adı Bulunamadı");

        }

        [Fact]
       public void WhenAllReadyExistGenreIdGiven_Genre_ShouldBeReturn()
        {
               //Arrenge
               GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
               query.GenreId =2;
               var result = query.Handle();

               //Act 
               FluentActions.Invoking(()=>query.Handle()).Invoke();

               //Assert
               var genre = _context.Genres.SingleOrDefault(x=>x.Id == 2);
               genre.Should().NotBeNull();
               genre.Name.Should().Be(result.Name);
               genre.Status.Should().Be(Convert.ToBoolean(result.Status));
        }
          
    }
}