using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.AuthorOperations.Queries;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.AuthorOperations.AuthorQuery
{
    public class GetAuthorDetailsQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenIvalidInputAreGivenAuthorId_Validator_ShoulBeReturnErrors()
        {
            //arrenge
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(null,null);
            query.AuthorId =0;

            //act
            GetAuthorDetailValidator  validator = new GetAuthorDetailValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenIvalidInputAreGivenAuthorId_Validator_ShoulNotBeReturnErrors()
        {
            //arrenge
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(null,null);
            query.AuthorId =10;

            //act
            GetAuthorDetailValidator  validator = new GetAuthorDetailValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeLessThan(1);
        }
    }
}