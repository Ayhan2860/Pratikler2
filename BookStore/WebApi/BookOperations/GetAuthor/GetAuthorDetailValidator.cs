using FluentValidation;

namespace WebApi.BookOperations.GetAuthor
{
    public class GetAuthorDetailValidator:AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailValidator()
        {
            RuleFor(a=>a.AuthorId).GreaterThan(0);
        }
    }
}