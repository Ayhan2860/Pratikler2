using System;
using System.Linq;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.AuthorOperations.Commands.UpdateAuthor;
using WebApi.DbOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.AuthorOperations.AuthorCommand
{
    public class UpdateAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
         private readonly BookStoreDbContext _context;
         public UpdateAuthorCommandTests(CommonTestFixture fixture)
         {
             _context = fixture.Context;
         }
        [Fact]
        public void WhenAllReadyExistUpdateAuthorIdGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrenge
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId =0; 
             
            //Act & Assert(Çalıştırma - Doğrulama)
             FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
             
        }
        [Fact]
        public void WhenAllReadyExistAuthorIdGiven_Author_ShouldBeUpdated()
        {
             //Arrenge
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId =3;
            UpdateAuthorViewModel model = new UpdateAuthorViewModel
            {
                FirstName = "Yasin",
                LastName = "Şahin",
                DateOfBirth = new DateTime(1970,01,16)
            };
            command.Model = model;
            //Act
             FluentActions.Invoking(()=>command.Handle()).Invoke();

             //Assert
             var author = _context.Authors.SingleOrDefault(x=>x.AuthorId == 3);
             author.Should().NotBeNull();
             author.FirstName.Should().Be(model.FirstName);
             author.LastName.Should().Be(model.LastName);
             author.DateOfBirth.Should().Be(model.DateOfBirth);
             
        }

    }
}