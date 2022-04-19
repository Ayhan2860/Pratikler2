using System;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.BookOperations.Commands.UpdateBook;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.BookOperations.Command
{
    public class UpdateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
         
         
          [Theory]
          [InlineData(2," ",0, 0, 0)]
           public void WhenInvalidInputBookIdAreGiven_Validator_ShouldBeReturnErrors(int id, string title, int pageCount, int genreId, int authorId)
         {
             //Arrenge
             UpdateBookCommand command = new UpdateBookCommand(null);
             command.BookId = id;
             command.Model = new UpdateBookModel
             {
                Title =title,
                GenreId =genreId,
                AuthorId = authorId,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-1)
            };
            
            //Act
            UpdateCommandValidator validator = new UpdateCommandValidator();
            var result = validator.Validate(command);
            
            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);

         }


        [Fact]
         public void WhenDateTimeEqualNowIsGiven_Valdator_ShouldBeReturnError()
            {
                //Arrenge
                UpdateBookCommand command = new UpdateBookCommand(null);
                command.BookId =2;
                command.Model = new UpdateBookModel{
                    Title = "Lord Of The Kings",
                    PageCount =1100,
                    PublishDate = DateTime.Now.Date,
                    GenreId = 1,
                    AuthorId =3
                };

                //Act
                UpdateCommandValidator validator = new UpdateCommandValidator();
                var result = validator.Validate(command);

                //Assert
                result.Errors.Count.Should().BeGreaterThan(0);
            }


            [Fact]
            public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnErrors()
            {
                //Arrenge
                UpdateBookCommand command = new UpdateBookCommand(null);
                command.Model = new UpdateBookModel{
                    Title = "Lord Of The Kings",
                    PageCount =100,
                    PublishDate = DateTime.Now.Date.AddYears(-2),
                    GenreId = 1,
                    AuthorId =1
                };

                //Act
                UpdateCommandValidator validator = new UpdateCommandValidator();
                var result = validator.Validate(command);

                //Assert
                result.Errors.Count.Should().Be(0);
            }
    }
}