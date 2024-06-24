using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Repair.Add
{
    public sealed class AddRepairCommandHandler : ICommandHandler<AddRepairCommand>
    {
        private readonly ICarWorkshopRepository _repository;

        public AddRepairCommandHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddRepairCommand command)
        {
            var validationResult = new AddRepairCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result.Fail(errorMessage);
            }

            var order = _repository.GetOrderById(command.OrderId);
            if (order == null)
            {
                return Result.Fail("Order not found");
            }

            var repair = new CarWorkshop.Storage.Entities.Repair(
                id: 0, 
                orderId: command.OrderId,
                order: order,
                repairDate: command.RepairDate,
                description: command.Description,
                cost: command.Cost
            );

            _repository.AddRepair(repair);
            return Result.Ok();
        }
    }
}
