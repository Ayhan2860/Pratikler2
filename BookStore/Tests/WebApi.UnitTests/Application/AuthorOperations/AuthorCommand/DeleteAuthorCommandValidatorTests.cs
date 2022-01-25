using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.AuthorOperations.Commands.DeleteAuthor;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.AuthorOperations.AuthorCommand
{
    public class DeleteAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
         public void WhenInvalidInputAuthorIdAreGiven_Validator_ShouldBeReturnErrors()
         {
             //arrenge
             DeleteAuthorCommand command = new DeleteAuthorCommand(null);
             command.AuthorId =0;

             //act
             DeleteAuthorValidator validator = new DeleteAuthorValidator();
             var result = validator.Validate(command);

             //assert
             result.Errors.Count.Should().BeGreaterThan(0);

         }

         [Fact]
         public void WhenInvalidInputAuthorIdAreGiven_Validator_ShouldNotBeReturnErrors()
         {
             //arrenge
             DeleteAuthorCommand command = new DeleteAuthorCommand(null);
             command.AuthorId =100;

             //act
             DeleteAuthorValidator validator = new DeleteAuthorValidator();
             var result = validator.Validate(command);

             //assert
             result.Errors.Count.Should().BeLessThan(1);

         }
    }
}