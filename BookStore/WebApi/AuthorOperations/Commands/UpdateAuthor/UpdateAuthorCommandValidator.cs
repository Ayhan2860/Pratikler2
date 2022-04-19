using System;
using FluentValidation;

namespace WebApi.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(a=>a.Model.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(a=>a.Model.LastName).NotEmpty().MinimumLength(3);
            RuleFor(a=>a.Model.DateOfBirth).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}