using System;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.AuthorOperations.Commands.CreateAuthor;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.AuthorOperations.AuthorCommand
{
    public class CreateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(" ", " ")]
        [InlineData("", "")]
        [InlineData("ay", "Karaman")]
        [InlineData("Ayhan", "ka")]
         public void WhenInvalidInputAuthorAreGiven_Validator_ShouldBeReturnErrors(string firstName, string lastName)
        {
                  //arrenge
                  CreateAuthorCommand   command = new CreateAuthorCommand(null,null);
                  command.Model = new CreateAuthorModel
                  {
                      FirstName = firstName,
                      LastName = lastName,
                      DateOfBirth = DateTime.Now.Date.AddYears(-1)
                  };
                 // act
                 AuthorCommandValidator validator = new AuthorCommandValidator();
                 var result = validator.Validate(command);
                //assert
                result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Valdator_ShouldBeReturnError()
        {
            CreateAuthorCommand   command = new CreateAuthorCommand(null,null);
                  command.Model = new CreateAuthorModel
                  {
                      FirstName = "Yasin",
                      LastName = "Şahin",
                      DateOfBirth = DateTime.Now.Date
                  };
                 // act
                 AuthorCommandValidator validator = new AuthorCommandValidator();
                 var result = validator.Validate(command);
                //assert
                result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAuthorAreGiven_Validator_ShouldNotBeReturnErrors()
        {
            CreateAuthorCommand   command = new CreateAuthorCommand(null,null);
                  command.Model = new CreateAuthorModel
                  {
                      FirstName = "Mevlüt",
                      LastName = "Karaman",
                      DateOfBirth = DateTime.Now.Date.AddYears(-1)
                  };
                 // act
                 AuthorCommandValidator validator = new AuthorCommandValidator();
                 var result = validator.Validate(command);
                //assert
                result.Errors.Count.Should().Be(0);
        }
    }
}