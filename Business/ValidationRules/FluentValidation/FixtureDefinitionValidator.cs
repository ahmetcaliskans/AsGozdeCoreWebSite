using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class FixtureDefinitionValidator : AbstractValidator<FixtureDefinition>
    {
        public FixtureDefinitionValidator()
        {
            /*Name*/
            RuleFor(b => b.Name).NotEmpty().WithMessage("Demirbaş Tanım Adı Boş Olamaz !");
            RuleFor(b => b.Name).MaximumLength(50).WithMessage("Demirbaş Tanım Adı En Fazla {MaxLength} Karakter Olmalı !");

            /*Description*/
            RuleFor(b => b.Description).MaximumLength(150).WithMessage("Demirbaş Açıklama En Fazla {MaxLength} Karakter Olmalı !");

            /*Note*/
            RuleFor(b => b.Note).MaximumLength(200).WithMessage("Demirbaş Not En Fazla {MaxLength} Karakter Olmalı !");
        }
    }
}
