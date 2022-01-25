using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.GenreOperations.Commands.UpdateCommand;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.GenreCommands
{
    public class UpdateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("Rom")]
         public void WhenInvalidInputBookIdAreGiven_Validator_ShouldBeReturnErrors(string name)
         {
             //Arrenge
             UpdateGenreCommand command = new UpdateGenreCommand(null,null);
             command.Model = new UpdateGenreViewModel{Name = name};

             //Act
             UpdateGenreValidator validator = new UpdateGenreValidator();
             var result = validator.Validate(command);

             //Assert
             result.Errors.Count.Should().BeGreaterThan(0);
         }
        [Fact]
         public void WhenInvalidInputBookIdAreGiven_Validator_ShouldNotBeReturnErrors()
         {
             //Arrenge
             UpdateGenreCommand command = new UpdateGenreCommand(null,null);
             command.GenreId =2;
             command.Model = new UpdateGenreViewModel{Name = "Roman"};

             //Act
             UpdateGenreValidator validator = new UpdateGenreValidator();
             var result = validator.Validate(command);

             //Assert
             result.Errors.Count.Should().Be(0);
         }
    }
}