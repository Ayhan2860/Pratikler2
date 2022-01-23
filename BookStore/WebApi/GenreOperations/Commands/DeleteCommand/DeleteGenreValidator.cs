using FluentValidation;

namespace WebApi.GenreOperations.Commands.DeleteCommand
{
    public class DeleteGenreValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreValidator()
        {
            RuleFor(x=>x.GenreId).GreaterThan(0);
        }
    }
}