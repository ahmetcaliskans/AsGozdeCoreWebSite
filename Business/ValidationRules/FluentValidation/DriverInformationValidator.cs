using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class DriverInformationValidator : AbstractValidator<DriverInformation>
    {
        public DriverInformationValidator()
        {
            /*Name*/
            RuleFor(b => b.Name).NotEmpty().WithMessage("Sürücü Adayı Adı Boş Olamaz !");
            RuleFor(b => b.Name).MaximumLength(70).WithMessage("Sürücü Adayı Adı En Fazla {MaxLength} Karakter Olmalı !");

            /*Surname*/
            RuleFor(b => b.Surname).NotEmpty().WithMessage("Sürücü Adayı Soyadı Boş Olamaz !");
            RuleFor(b => b.Surname).MaximumLength(100).WithMessage("Sürücü Adayı Soyadı En Fazla {MaxLength} Karakter Olmalı !");

            /*IdentityNo*/
            RuleFor(b => b.IdentityNo).NotEmpty().WithMessage("Tc Kimlik No Boş Olamaz !");
            RuleFor(b => b.IdentityNo).MaximumLength(11).WithMessage("Tc Kimlik No En Fazla {MaxLength} Karakter Olmalı !");

            /*FatherName*/
            RuleFor(b => b.FatherName).MaximumLength(150).WithMessage("Baba Adı En Fazla {MaxLength} Karakter Olmalı !");

            /*BirthPlace*/
            RuleFor(b => b.BirthPlace).MaximumLength(150).WithMessage("Doğum Yeri En Fazla {MaxLength} Karakter Olmalı !");

            /*Email*/
            RuleFor(b => b.Email).MaximumLength(50).WithMessage("Email En Fazla {MaxLength} Karakter Olmalı !");

            /*Phone1*/
            RuleFor(b => b.Phone1).NotEmpty().WithMessage("Telefon 1  Boş Olamaz !");
            RuleFor(b => b.Phone1).MaximumLength(15).WithMessage("Telefon 1 En Fazla {MaxLength} Karakter Olmalı !");

            /*Phone2*/
            RuleFor(b => b.Phone2).NotEmpty().WithMessage("Telefon 2  Boş Olamaz !");
            RuleFor(b => b.Phone2).MaximumLength(15).WithMessage("Telefon 2 En Fazla {MaxLength} Karakter Olmalı !");

            /*City*/
            RuleFor(b => b.City).NotEmpty().WithMessage("İl Boş Olamaz !");
            RuleFor(b => b.City).MaximumLength(50).WithMessage("İl En Fazla {MaxLength} Karakter Olmalı !");

            /*County*/
            RuleFor(b => b.County).NotEmpty().WithMessage("İlçe Boş Olamaz !");
            RuleFor(b => b.County).MaximumLength(50).WithMessage("İlçe En Fazla {MaxLength} Karakter Olmalı !");

            /*Address1*/
            RuleFor(b => b.Address1).NotEmpty().WithMessage("Adres 1 Boş Olamaz !");
            RuleFor(b => b.Address1).MaximumLength(100).WithMessage("Adres 1 En Fazla {MaxLength} Karakter Olmalı !");

            /*Address2*/
            RuleFor(b => b.Address2).MaximumLength(100).WithMessage("Adres 2 En Fazla {MaxLength} Karakter Olmalı !");

            /*RecordDate*/
            RuleFor(b => b.RecordDate).NotEmpty().WithMessage("Kayıt Tarihi Boş Olamaz !");

            /*Note*/
            RuleFor(b => b.Note).MaximumLength(200).WithMessage("Not En Fazla {MaxLength} Karakter Olmalı !");

            /*CertificateDeliveredDate*/
            RuleFor(b => b.CertificateDeliveredDate).NotEmpty().When(b=>b.IsCertificateDelivered).WithMessage("Sertifika Tarihi Boş Olamaz !");

            /*RecordNumber*/
            RuleFor(b => b.RecordNumber).MaximumLength(50).WithMessage("Kayıt Numarası En Fazla {MaxLength} Karakter Olmalı !");
        }
    }
}
