using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.ReceiverMail).NotEmpty().WithMessage("Alıcı mail adresini boş geçemezsiniz.");
            RuleFor(m => m.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz.");
            RuleFor(m => m.Content).NotEmpty().WithMessage("Mesajı boş geçemezsiniz.");
            RuleFor(m => m.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
            RuleFor(m => m.Subject).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter girişi yapın.");
            RuleFor(m => m.ReceiverMail).EmailAddress().WithMessage("Lütfen doğru bir email adresi giriniz.");
            RuleFor(m => m.ReceiverMail).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter girişi yapın.");
        }
    }
}
