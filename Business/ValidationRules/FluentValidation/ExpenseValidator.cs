using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ExpenseValidator : AbstractValidator<Expense>
    {
        public ExpenseValidator()
        {
            /*ExpenseDate*/
            RuleFor(b => b.ExpenseDate).NotEmpty().WithMessage("Gider Tarihi Boş Olamaz !");

            /*Description*/
            RuleFor(b => b.Description).MaximumLength(150).WithMessage("Gider Açıklama En Fazla {MaxLength} Karakter Olmalı !"); 
        }
    }
}
