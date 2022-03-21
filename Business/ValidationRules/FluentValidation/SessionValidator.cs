using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class SessionValidator : AbstractValidator<Session>
    {
        public SessionValidator()
        {
            /*Name*/
            RuleFor(s => s.Name).NotEmpty().WithMessage("Dönem Adı Boş Olamaz !");
            RuleFor(s => s.Name).MaximumLength(50).WithMessage("Dönem Adı En Fazla 50 Karakter Olabilir !");

            /*Description*/
            RuleFor(s => s.Description).MaximumLength(150).WithMessage("Açıklama En Fazla 150 Karakter Olabilir !");
        }
    }
}
