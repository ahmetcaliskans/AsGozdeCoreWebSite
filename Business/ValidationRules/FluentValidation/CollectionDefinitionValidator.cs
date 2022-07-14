using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CollectionDefinitionValidator : AbstractValidator<CollectionDefinition>
    {
        public CollectionDefinitionValidator()
        {
            /*Name*/
            RuleFor(c => c.Name).NotEmpty().WithMessage("Tahsilat Adı Boş Olamaz !");
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Tahsilat Adı En Az {MinLength} Karakter Olmalı !");
            RuleFor(c => c.Name).MaximumLength(100).WithMessage("Tahsilat Adı En Fazla {MaxLength} Karakter Olmalı !");

            /*Description*/
            RuleFor(c => c.Description).MaximumLength(150).WithMessage("Açıklama En Fazla {MaxLength} Karakter Olmalı !");

            /*Sequence*/
            RuleFor(c => c.Sequence).GreaterThanOrEqualTo(0).WithMessage("Sıfırdan({ComparisonValue}) Büyük Bir Sıra Numarası Giriniz !");

        }
    }
}
