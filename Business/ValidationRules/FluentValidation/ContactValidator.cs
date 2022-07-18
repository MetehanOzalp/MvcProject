﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz.");
            RuleFor(c => c.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz.");
            RuleFor(c => c.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
            RuleFor(c => c.Subject).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın.");
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz");
            RuleFor(c => c.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
        }
    }
}
