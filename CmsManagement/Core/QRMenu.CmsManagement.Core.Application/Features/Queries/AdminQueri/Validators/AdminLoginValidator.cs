using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Queries;

namespace QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Validators
{
    public class AdminLoginValidator : AbstractValidator<AdminLoginQuery>
    {
        public AdminLoginValidator()
        {
            RuleFor(x => x.AdminEmail).NotNull().WithMessage("Lütfen Email adresini boş bırakmayınız !").
                NotEmpty().WithMessage("Lütfen Email adresini boş bırakmayınız !").
                MaximumLength(50).WithMessage("Email en fazla 50 olabilir").
                MinimumLength(5).WithMessage("Email en az 50 olabilir");

            RuleFor(x => x.AdminPassword).
                NotEmpty().
                WithMessage("Lütfen Email adresini boş bırakmayınız !").
                NotNull().WithMessage("Lütfen Email adresini boş bırakmayınız !").
                MaximumLength(25).WithMessage("Şifre En fazla 25 karakter olabilir").
                MinimumLength(6).WithMessage("Şifre En az 6 karakter olabilir");
        }
    }
}
