using FluentValidation;

namespace WebApi.AuthorOperations.Queries
{
    public class GetAuthorDetailValidator:AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailValidator()
        {
            RuleFor(a=>a.AuthorId).GreaterThan(0);
        }
    }
}