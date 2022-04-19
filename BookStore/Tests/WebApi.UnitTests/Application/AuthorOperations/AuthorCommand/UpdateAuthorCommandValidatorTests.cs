using System;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.AuthorOperations.Commands.UpdateAuthor;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.AuthorOperations.AuthorCommand
{
    public class UpdateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(" ", " ")]
        [InlineData("", "")]
        [InlineData("ay", "Karaman")]
        [InlineData("Ayhan", "ka")]
          public void WhenInvalidInputAuthorIdAreGiven_Validator_ShouldBeReturnErrors(string firstName, string lastName)
         {
             //Arrenge
              UpdateAuthorCommand command = new UpdateAuthorCommand(null);
              command.AuthorId = 2;
              command.Model = new UpdateAuthorViewModel{
                  FirstName = firstName,
                  LastName = lastName,
                  DateOfBirth = new DateTime(1970,01,16)
                  
              };
            //Act
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);
           //Assert
           result.Errors.Count.Should().BeGreaterThan(0);

         }


         [Fact]
         public void WhenDateTimeEqualNowIsGiven_Valdator_ShouldBeReturnError()
            {
                //Arrenge
                UpdateAuthorCommand command = new UpdateAuthorCommand(null);
                command.AuthorId =2;
                command.Model = new UpdateAuthorViewModel{
                FirstName = "Ayhan",
                LastName = "Karaman",
                DateOfBirth = DateTime.Now.Date
                };

                //Act
                UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
                var result = validator.Validate(command);

                //Assert
                result.Errors.Count.Should().BeGreaterThan(0);
            }

           [Fact]
            public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnErrors()
            {
                UpdateAuthorCommand command = new UpdateAuthorCommand(null);
                command.AuthorId =2;
                command.Model = new UpdateAuthorViewModel{
                FirstName = "Ayhan",
                LastName = "Karaman",
                DateOfBirth = new DateTime(1970,01,16)
                };

                //Act
                UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
                var result = validator.Validate(command);

                //Assert
                result.Errors.Count.Should().Be(0);
            } 
    }
}