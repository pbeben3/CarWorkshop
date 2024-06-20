using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Repair.Edit
{
    public class EditRepairCommandValidator : AbstractValidator<EditRepairCommand>
    {
        public EditRepairCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.OrderId).NotNull();
            RuleFor(x => x.RepairDate).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Cost).GreaterThan(0);
        }
    }
}
