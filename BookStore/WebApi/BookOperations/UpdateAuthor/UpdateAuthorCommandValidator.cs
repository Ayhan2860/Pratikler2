using System;
using FluentValidation;

namespace WebApi.BookOperations.UpdateAuthor
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