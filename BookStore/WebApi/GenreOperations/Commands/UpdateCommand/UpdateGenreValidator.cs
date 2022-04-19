using FluentValidation;

namespace WebApi.GenreOperations.Commands.UpdateCommand
{
    public class UpdateGenreValidator:AbstractValidator<UpdateGenreCommand>
    {
       public UpdateGenreValidator()
       {
           RuleFor(x=>x.GenreId).GreaterThan(0);
           RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(4);
           RuleFor(x=>x.Model).NotEmpty();
       }   
    }
}