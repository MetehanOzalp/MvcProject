using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.Name).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(w => w.SurName).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz.");
            RuleFor(w => w.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın.");
            RuleFor(w => w.Name).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın.");
            RuleFor(w => w.SurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın.");
            RuleFor(w => w.SurName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın.");
            RuleFor(w => w.About).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz.");
            RuleFor(w => w.Title).NotEmpty().WithMessage("Unvan kısmını boş geçemezsiniz.");
            RuleFor(w => w.Title).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın.");
        }
    }
}
