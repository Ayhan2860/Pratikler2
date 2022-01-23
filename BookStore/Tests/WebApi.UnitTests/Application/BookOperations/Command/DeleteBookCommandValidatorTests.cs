using System;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.BookOperations.Commands.DeleteBook;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.BookOperations.Command
{
    public class DeleteBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {

          
          [Fact]
          public void WhenInvalidInputBookIdAreGiven_Validator_ShouldBeReturnErrors()
         {
                //Arrenge
                DeleteBookCommand command = new DeleteBookCommand(null);
                command.BookId = 0;
                //Act
                BookDeleteCommandValidator validator = new BookDeleteCommandValidator();
                var result = validator.Validate(command);

                //Assert
                result.Errors.Count.Should().BeGreaterThan(0);

         }
    }
}