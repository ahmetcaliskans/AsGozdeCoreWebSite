using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ExpenseDefinitionValidator : AbstractValidator<ExpenseDefinition>
    {
        public ExpenseDefinitionValidator()
        {
            /*Name*/
            RuleFor(b => b.Name).NotEmpty().WithMessage("Gider Tanım Adı Boş Olamaz !");
            RuleFor(b => b.Name).MaximumLength(50).WithMessage("Gider Tanım Adı En Fazla {MaxLength} Karakter Olmalı !");

            /*Description*/
            RuleFor(b => b.Description).MaximumLength(150).WithMessage("Gider Açıklama En Fazla {MaxLength} Karakter Olmalı !");
            
        }
    }
}
