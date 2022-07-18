using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Command;

namespace QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Validators
{
    public class AdminProfileUpdateValidator : AbstractValidator<AdminProfileUpdateComman>
    {
        public AdminProfileUpdateValidator()
        {
            RuleFor(x => x.AdminName).
               NotEmpty().
               WithMessage("{0} boş bırakılamaz").
               NotNull().WithMessage("{0} alanı boş bırakılamaz").
               MaximumLength(25).WithMessage("En fazla {0} olabilir").
               MinimumLength(3).WithMessage("En az {0} olabilir");

            RuleFor(x => x.AdminSurName).
                NotEmpty().
                WithMessage("{0} boş bırakılamaz").
                NotNull().WithMessage("{0} alanı boş bırakılamaz").
                MaximumLength(25).WithMessage("En fazla {0} olabilir").
                MinimumLength(3).WithMessage("En az {0} olabilir");

            RuleFor(x => x.AdminEmail).
                NotEmpty().
                WithMessage("Email adredi boş bırakılamaz").
                NotNull().
                MaximumLength(50).WithMessage("en fazla {0} olabilir").
                MinimumLength(5).WithMessage("En az {0} olabilir");

            RuleFor(x => x.AdminPassword).
                MaximumLength(25).WithMessage("En fazla {0} olabilir").
                MinimumLength(6).WithMessage("En az {0} olabilir");

            RuleFor(x => x.AdminPasswordNew).
                MaximumLength(25).WithMessage("En fazla {0} olabilir").
                MinimumLength(6).WithMessage("En az {0} olabilir");

            RuleFor(x => x.adminPasswordNewControl).
                MaximumLength(25).WithMessage("En fazla {0} olabilir").
                MinimumLength(6).WithMessage("En az {0} olabilir").
                Equal(x => x.AdminPassword).WithMessage("Şifre uyuşmuyor lütfen tekrar deneyin");
        }
    }
}
