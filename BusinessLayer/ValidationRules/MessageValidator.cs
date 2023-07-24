using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageReceiver).NotEmpty().WithMessage("Alıcı Adresi Boş Bırakılamaz");
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konu Adı Boş Bırakılamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Boş Bırakılamaz");
            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir");
            RuleFor(x => x.MessageSubject).MaximumLength(50).WithMessage("Konu Uzunluğu Max 100 Karakter Olmalıdır");

        }
    }
}
