using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Order.Edit
{
    public class UpdateOrderStatusCommandHandler : ICommandHandler<UpdateOrderStatusCommand>
    {
        private readonly ICarWorkshopRepository _repository;

        public UpdateOrderStatusCommandHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(UpdateOrderStatusCommand command)
        {
            var validationResult = new UpdateOrderStatusCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result.Fail(errorMessage);
            }

            var order = _repository.GetOrderById(command.OrderId);
            if (order == null)
            {
                return Result.Fail("Order not found.");
            }

            order.Status = command.NewStatus;
            _repository.EditOrder(order);

            return Result.Ok();
        }
    }
}
