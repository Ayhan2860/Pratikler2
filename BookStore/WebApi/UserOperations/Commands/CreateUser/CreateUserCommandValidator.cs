using FluentValidation;

namespace WebApi.UserOperations.Commands.CreateUser
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x=>x.Model.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(x=>x.Model.LastName).NotEmpty().MinimumLength(3);
            RuleFor(x=>x.Model.Password).NotEmpty().MinimumLength(6);
            RuleFor(x=>x.Model.Email).NotEmpty().EmailAddress();
        }
    }
}