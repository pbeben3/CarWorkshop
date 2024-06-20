using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Repair.Edit
{
    public sealed class EditRepairCommandHandler : ICommandHandler<EditRepairCommand>
    {
        private readonly ICarWorkshopRepository _repository;

        public EditRepairCommandHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(EditRepairCommand command)
        {
            var validationResult = new EditRepairCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToArray());
            }

            var repair = _repository.GetRepairById(command.Id);
            if (repair == null)
            {
                return Result.Fail("Repair not found");
            }

            var order = _repository.GetOrderById(command.OrderId);
            if (order == null)
            {
                return Result.Fail("Order not found");
            }

            repair.OrderId = command.OrderId;
            repair.RepairDate = command.RepairDate;
            repair.Description = command.Description;
            repair.Cost = command.Cost;

            _repository.EditRepair(repair);

            return Result.Ok();
        }
    }
}
