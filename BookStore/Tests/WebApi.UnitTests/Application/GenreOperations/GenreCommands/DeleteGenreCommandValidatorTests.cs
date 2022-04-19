using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.GenreOperations.Commands.DeleteCommand;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.GenreCommands
{
    public class DeleteGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputGenreIdAreGiven_Validator_ShouldBeReturnErrors()
        {
               //Arrenge
               DeleteGenreCommand command = new DeleteGenreCommand(null);
               command.GenreId =0;
               
               //Act
               DeleteGenreValidator validator = new DeleteGenreValidator();
               var result = validator.Validate(command);
               //Assert
               result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenInvalidInputGenreIdAreGiven_Validator_ShouldNotBeReturnErrors()
        {
               //Arrenge
               DeleteGenreCommand command = new DeleteGenreCommand(null);
               command.GenreId =100;
               
               //Act
               DeleteGenreValidator validator = new DeleteGenreValidator();
               var result = validator.Validate(command);
               //Assert
               result.Errors.Count.Should().BeLessThan(1);

        }
    }
}