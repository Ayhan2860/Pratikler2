using System;
using FluentValidation;

namespace WebApi.BookOperations.CreateAuthor
{
    public class AuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public AuthorCommandValidator()
        {
            RuleFor(a=>a.Model.FirstName).NotEmpty();
            RuleFor(a=>a.Model.LastName).NotEmpty();

            RuleFor(a=>a.Model.FirstName).MinimumLength(3);
            RuleFor(a=>a.Model.LastName).MinimumLength(3);

            RuleFor(a=>a.Model.DateOfBirth).NotEmpty().LessThan(DateTime.Now.Date);
           
        }
    }
}