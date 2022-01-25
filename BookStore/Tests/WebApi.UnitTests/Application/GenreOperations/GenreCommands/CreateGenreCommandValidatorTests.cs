using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.GenreOperations.Commands.CreateCommand;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.GenreCommands
{
    public class CreateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {   
         [Theory]
         [InlineData("")]
         [InlineData(" ")]
         [InlineData("Kor")]
         public void WhenInvalidInputGenreAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            //Arrenge
           CreateGenreCommand command = new CreateGenreCommand(null,null);
           command.Model = new CreateGenreViewModel
           {
               Name = name
           };
           //Act
           CreateGenreValidator validator = new CreateGenreValidator();
           var result = validator.Validate(command);

           //Assert
           result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenInvalidInputGenreAreGiven_Validator_ShouldNotBeReturnErrors()
        {
            //Arrenge
           CreateGenreCommand command = new CreateGenreCommand(null,null);
           command.Model = new CreateGenreViewModel
           {
               Name = "Romantizm"
           };
           //Act
           CreateGenreValidator validator = new CreateGenreValidator();
           var result = validator.Validate(command);

           //Assert
           result.Errors.Count.Should().BeLessThan(1);
        }
    }
}