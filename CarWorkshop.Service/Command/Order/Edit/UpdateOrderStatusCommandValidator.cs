using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CarWorkshop.Service.Command.Order.Edit
{
    public class UpdateOrderStatusCommandValidator :  AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderStatusCommandValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.NewStatus).NotEmpty().MaximumLength(100); ;
        }
    }
}
