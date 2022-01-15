using FluentValidation;

namespace WebApi.BookOperations.DeleteAuthor
{
    public class DeleteAuthorValidator:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(author=>author.AuthorId).GreaterThan(0);
        }
    }
}