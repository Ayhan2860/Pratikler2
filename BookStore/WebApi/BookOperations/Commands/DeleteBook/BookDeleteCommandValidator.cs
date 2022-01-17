using FluentValidation;

namespace WebApi.BookOperations.Commands.DeleteBook
{
    public class BookDeleteCommandValidator:AbstractValidator<DeleteBookCommand>
    {
        public BookDeleteCommandValidator()
        {
            RuleFor(book =>book.BookId).GreaterThan(0);
        }
    }
}