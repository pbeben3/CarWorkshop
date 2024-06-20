using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Client.Add
{
    public class AddClientValidator : AbstractValidator<AddClientCommand>
    {
        public AddClientValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3);
            RuleFor(x => x.Name).MaximumLength(30);

            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Surname).MinimumLength(3);
            RuleFor(x => x.Surname).MaximumLength(30);

            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).MinimumLength(3);
            RuleFor(x => x.Email).MaximumLength(30);
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
