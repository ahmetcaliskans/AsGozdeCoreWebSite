using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class OfficeValidator : AbstractValidator<Office>
    {
        public OfficeValidator()
        {
            /*Name*/
            RuleFor(o => o.Name).NotEmpty().WithMessage("Şube Adı Boş Olamaz !");
            RuleFor(o => o.Name).MaximumLength(100).WithMessage("Şube Adı En Fazla 100 Karakter Olmalı !");

            /*Description*/
            RuleFor(o => o.Description).MaximumLength(150).WithMessage("Açıklama En Fazla 150 Karakter Olmalı !");

            /*WebAddress*/
            RuleFor(o => o.WebAddress).MaximumLength(50).WithMessage("Web Adresi En Fazla 50 Karakter Olmalı !");

            /*Email*/
            RuleFor(o => o.Email).MaximumLength(50).WithMessage("Email En Fazla 50 Karakter Olmalı !");

            /*Phone1*/
            RuleFor(o => o.Phone1).MaximumLength(15).WithMessage("Telefon 1 En Fazla 15 Karakter Olmalı !");

            /*Phone2*/
            RuleFor(o => o.Phone2).MaximumLength(15).WithMessage("Telefon 2 En Fazla 15 Karakter Olmalı !");

            /*Fax*/
            RuleFor(o => o.Fax).MaximumLength(15).WithMessage("Fax En Fazla 15 Karakter Olmalı !");

            /*City*/
            RuleFor(o => o.City).MaximumLength(50).WithMessage("İl En Fazla 50 Karakter Olmalı !");

            /*County*/
            RuleFor(o => o.County).MaximumLength(50).WithMessage("İlçe En Fazla 50 Karakter Olmalı !");

            /*Address1*/
            RuleFor(o => o.Address1).MaximumLength(100).WithMessage("Adres 1 En Fazla 100 Karakter Olmalı !");

            /*Address2*/
            RuleFor(o => o.Address2).MaximumLength(100).WithMessage("Adres 2 En Fazla 100 Karakter Olmalı !");

            /*TradeRegisterNumber*/
            RuleFor(o => o.TradeRegisterNumber).MaximumLength(20).WithMessage("Ticaret Sicil No En Fazla 20 Karakter Olmalı !");

            /*TaxOfficeName*/
            RuleFor(o => o.TaxOfficeName).MaximumLength(50).WithMessage("Vergi Dairesi Adı En Fazla 50 Karakter Olmalı !");

            /*TaxOfficeNo*/
            RuleFor(o => o.TaxOfficeNo).MaximumLength(20).WithMessage("Vergi No En Fazla 20 Karakter Olmalı !");
        }
    }
}
