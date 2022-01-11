using FluentValidation;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBookDetailValidator:AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailValidator()
        {
            RuleFor(book =>book.BookId).GreaterThan(0).WithMessage("Kitap Id si sıfırdan büyük olmalıdır.");
        }
    }
}