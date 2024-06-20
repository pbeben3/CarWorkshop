using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace CarWorkshop.Service.Command.Repair.Add
{
    public class AddRepairCommandValidator : AbstractValidator<AddRepairCommand>
    {
        public AddRepairCommandValidator()
        {
            RuleFor(x => x.OrderId).GreaterThan(0);
            RuleFor(x => x.RepairDate).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Cost).GreaterThan(0);
        }
    }
}
