using FluentValidation;

namespace WebApi.UserOperations.Commands.CreateUser
{
    public class CreateTokenCommandValidator:AbstractValidator<CreateTokenCommand>
    {
         public CreateTokenCommandValidator()
         {
             RuleFor(x=>x.Model.Email).NotEmpty().EmailAddress();
             RuleFor(x=>x.Model.Password).NotEmpty();
         }
    }
}