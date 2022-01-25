using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.BookOperations.Queries;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.BookOperations.GetBooks
{
    public class GetBookDetailsQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        
        [Fact]
        public void WhenIvalidInputAreGivenId_Validator_ShoulBeReturnErrors()
        {
            //arrenge
            GetBookDetailQuery query = new GetBookDetailQuery(null,null);
            query.BookId = 0;

            //act
            GetBookDetailValidator validator = new GetBookDetailValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

         [Fact]
        public void WhenIvalidInputAreGivenId_Validator_ShoulNotBeReturnErrors()
        {
            //arrenge
            GetBookDetailQuery query = new GetBookDetailQuery(null,null);
            query.BookId = 1;

            //act
            GetBookDetailValidator validator = new GetBookDetailValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}