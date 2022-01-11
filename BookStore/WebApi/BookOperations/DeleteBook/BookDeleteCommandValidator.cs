using FluentValidation;

namespace WebApi.BookOperations.DeleteBook
{
    public class BookDeleteCommandValidator:AbstractValidator<DeleteBookCommand>
    {
        public BookDeleteCommandValidator()
        {
            RuleFor(book =>book.BookId).GreaterThan(0);
        }
    }
}