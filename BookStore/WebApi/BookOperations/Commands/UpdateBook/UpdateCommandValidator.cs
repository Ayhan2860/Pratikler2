using System;
using FluentValidation;

namespace WebApi.BookOperations.Commands.UpdateBook
{
    public class UpdateCommandValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(book =>book.Model.Title).NotEmpty().MinimumLength(4).WithMessage("Kitap ismi boş geçilemez");
            RuleFor(book =>book.Model.GenreId).GreaterThan(0);
            RuleFor(book =>book.Model.PageCount).GreaterThan(0).WithMessage("Sayfa sayısı sıfırdan büyük olmalı");
            RuleFor(book =>book.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}