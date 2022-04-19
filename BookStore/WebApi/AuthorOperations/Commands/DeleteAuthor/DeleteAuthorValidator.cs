using FluentValidation;

namespace WebApi.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorValidator:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(author=>author.AuthorId).GreaterThan(0);
        }
    }
}