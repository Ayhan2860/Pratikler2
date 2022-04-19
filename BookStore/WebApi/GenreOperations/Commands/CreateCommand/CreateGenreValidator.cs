using FluentValidation;

namespace WebApi.GenreOperations.Commands.CreateCommand
{
    public class CreateGenreValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}