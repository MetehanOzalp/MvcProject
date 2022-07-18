using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz.");
            RuleFor(c => c.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
            RuleFor(c => c.Name).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapın.");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz");
            RuleFor(c => c.ColorCode).NotEmpty().WithMessage("Renk kodunu boş geçemezsiniz");
            RuleFor(c => c.Name).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapın.");
        }
    }
}
