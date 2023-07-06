using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Bırakılamaz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Bırakılamaz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Alanı Boş Bırakılamaz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar Adı 2 Karakterden Az Olamaz.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Yazar Adı 50 Karakterden Fazla Olamaz.");
        }
    }
}
