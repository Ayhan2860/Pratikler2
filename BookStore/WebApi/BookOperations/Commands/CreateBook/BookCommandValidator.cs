using System;
using FluentValidation;

namespace WebApi.BookOperations.Commands.CreateBook
{
    public class BookCommandValidator:AbstractValidator<CreateBookCommand>
    {
        public BookCommandValidator()
        {
            RuleFor(book =>book.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(book =>book.Model.GenreId).GreaterThan(0);
            RuleFor(book =>book.Model.PageCount).GreaterThan(0);
            RuleFor(book =>book.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);

        }
    }
}