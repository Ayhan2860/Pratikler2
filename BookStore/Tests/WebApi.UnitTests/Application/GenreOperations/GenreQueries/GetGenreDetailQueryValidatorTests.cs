using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.GenreOperations.Queries;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.GenreQuery
{
    public class  GetGenreDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenIvalidInputAreGivenId_Validator_ShoulBeReturnErrors()
        {
            //Arrenge
            GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
            query.GenreId = 0;

            //Act
            GetGenreDetailValidator validator = new GetGenreDetailValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenIvalidInputAreGivenId_Validator_ShoulNotBeReturnErrors()
        {
            //Arrenge
            GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
            query.GenreId = 10;

            //Act
            GetGenreDetailValidator validator = new GetGenreDetailValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().BeLessThan(1);

        }
    }
}