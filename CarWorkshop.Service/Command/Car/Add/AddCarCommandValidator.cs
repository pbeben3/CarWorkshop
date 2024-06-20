using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Car.Add
{
    public class AddCarCommandValidator : AbstractValidator<AddCarCommand>
    {
        public AddCarCommandValidator()
        {
            RuleFor(x => x.ClientId).NotEmpty();
            RuleFor(x => x.Brand).NotEmpty().Length(3, 20);
            RuleFor(x => x.Model).NotEmpty().MaximumLength(20);
            RuleFor(x => x.ProductionYear).NotEmpty();
        }
    }
}
