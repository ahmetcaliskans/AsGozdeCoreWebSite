using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BranchValidator :AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            /*Name*/
            RuleFor(b=> b.Name).NotEmpty().WithMessage("Branş Adı Boş Olamaz !");
            RuleFor(b => b.Name).MaximumLength(50).WithMessage("Branş Adı En Fazla 50 Karakter Olmalı !");

            /*Description*/
            RuleFor(b => b.Description).MaximumLength(150).WithMessage("Açıklama En Fazla 150 Karakter Olmalı !");
        }
    }
}
