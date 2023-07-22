using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Mail Adresi Boş Bırakılamaz");
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Konu Adı Boş Bırakılamaz");
            RuleFor(x => x.ContactUsername).NotEmpty().WithMessage("Kullanıcı Adı Boş Bırakılamaz");
            RuleFor(x => x.ContactSubject).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir");
            RuleFor(x => x.ContactUsername).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir");
            RuleFor(x => x.ContactSubject).MaximumLength(50).WithMessage("Konu Uzunluğu Max 50 Karakter Olmalıdır");
            RuleFor(x => x.ContactMessage).MinimumLength(18).WithMessage("Mesaj Min 18 Karakter Olmalıdır");
        }
    }
}
