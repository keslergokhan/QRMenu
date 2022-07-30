using FluentValidation;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LanguageCommand.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Features.Commands.LanguageCommand.Validators
{
    public class LanguageAddValidator : AbstractValidator<LanguageAddCommand>
    {
        public LanguageAddValidator()
        {
            RuleFor(x=>x.LanguageName).
                NotEmpty().
                WithMessage("{0} boş bırakılamaz").
                NotNull().WithMessage("{0} alanı boş bırakılamaz").
                MaximumLength(20).WithMessage("En fazla {0} olabilir").
                MinimumLength(3).WithMessage("En az {0} olabilir");

            RuleFor(x=>x.LanguageCode).
                NotEmpty().
                WithMessage("{0} boş bırakılamaz").
                NotNull().WithMessage("{0} alanı boş bırakılamaz").
                MaximumLength(5).WithMessage("En fazla {0} olabilir").
                MinimumLength(2).WithMessage("En az {0} olabilir");

            RuleFor(x => x.LanguageCode).
                NotEmpty().
                WithMessage("{0} boş bırakılamaz").
                NotNull().WithMessage("{0} alanı boş bırakılamaz");

            RuleFor(x => x.Sorting).
                NotEmpty().
                WithMessage("{0} boş bırakılamaz").
                NotNull().WithMessage("{0} alanı boş bırakılamaz");

        }
    }
}
