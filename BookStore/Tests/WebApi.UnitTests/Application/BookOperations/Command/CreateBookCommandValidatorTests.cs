using System;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.BookOperations.Commands.CreateBook;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.BookOperations.Command
{
    public class CreateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
            [Theory]
            [InlineData(" ",0, 0, 0)]
            [InlineData("Loard Of The Rings",0, 0, 0)]
            [InlineData("Loard Of The Rings",0, 0, 1)]
            [InlineData("",0, 0, 0)]
            [InlineData("Lor",100, 1, 0)]
            [InlineData("Lord",0, 0, 0)]
            [InlineData("Lord",100, 0, 0)]
            [InlineData("Lord",0, 100, 0)]
            public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId, int authorId)
            {
                //Arrenge
                CreateBookCommand command = new CreateBookCommand(null,null);
                command.Model = new CreateBookModel{
                    Title = title,
                    PageCount =pageCount,
                    PublishDate = DateTime.Now.Date.AddYears(-1),
                    GenreId = genreId,
                    AuthorId =authorId
                };

                //Act
                BookCommandValidator validator = new BookCommandValidator();
                var result = validator.Validate(command);

                //Assert
                result.Errors.Count.Should().BeGreaterThan(0);
            }

            [Fact]
            public void WhenDateTimeEqualNowIsGiven_Valdator_ShouldBeReturnError()
            {
                //Arrenge
                CreateBookCommand command = new CreateBookCommand(null,null);
                command.Model = new CreateBookModel{
                    Title = "Lord Of The Kings",
                    PageCount =1100,
                    PublishDate = DateTime.Now.Date,
                    GenreId = 1,
                    AuthorId =3
                };

                //Act
                BookCommandValidator validator = new BookCommandValidator();
                var result = validator.Validate(command);

                //Assert
                result.Errors.Count.Should().BeGreaterThan(0);
            }

            [Fact]
            public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnErrors()
            {
                //Arrenge
                CreateBookCommand command = new CreateBookCommand(null,null);
                command.Model = new CreateBookModel{
                    Title = "Lord Of The Kings",
                    PageCount =100,
                    PublishDate = DateTime.Now.Date.AddYears(-2),
                    GenreId = 1,
                    AuthorId =1
                };

                //Act
                BookCommandValidator validator = new BookCommandValidator();
                var result = validator.Validate(command);

                //Assert
                result.Errors.Count.Should().Be(0);
            }
    }
}    