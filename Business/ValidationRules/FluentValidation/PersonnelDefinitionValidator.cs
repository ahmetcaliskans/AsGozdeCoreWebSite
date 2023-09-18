using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonnelDefinitionValidator : AbstractValidator<PersonnelDefinition>
    {
        public PersonnelDefinitionValidator()
        {
            /*Name*/
            RuleFor(b => b.Name).NotEmpty().WithMessage("Personel Adı Boş Olamaz !");
            RuleFor(b => b.Name).MaximumLength(70).WithMessage("Personel Adı En Fazla {MaxLength} Karakter Olmalı !");

            /*Surname*/
            RuleFor(b => b.Surname).NotEmpty().WithMessage("Personel Soyadı Boş Olamaz !");
            RuleFor(b => b.Surname).MaximumLength(100).WithMessage("Personel Soyadı En Fazla {MaxLength} Karakter Olmalı !");

            /*IdentityNo*/
            RuleFor(b => b.IdentityNo).NotEmpty().WithMessage("Tc Kimlik No Boş Olamaz !");
            RuleFor(b => b.IdentityNo).MaximumLength(11).WithMessage("Tc Kimlik No En Fazla {MaxLength} Karakter Olmalı !");

            /*BranchsName*/
            RuleFor(b => b.BranchsName).MaximumLength(200).WithMessage("Sürücü Belgesi Bilgileri En Fazla {MaxLength} Karakter Olmalı !");

            /*BranchFileNo*/
            RuleFor(b => b.BranchFileNo).MaximumLength(200).WithMessage("Sürücü Belge No En Fazla {MaxLength} Karakter Olmalı !");

            /*PlaceofBranchFileGiven*/
            RuleFor(b => b.PlaceofBranchFileGiven).MaximumLength(200).WithMessage("Sürücü Belgesi Verildiği Yer En Fazla {MaxLength} Karakter Olmalı !");
        }
    }
}
