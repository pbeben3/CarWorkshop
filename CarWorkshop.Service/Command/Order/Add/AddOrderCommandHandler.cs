using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Order.Add
{
    public sealed class AddOrderCommandHandler : ICommandHandler<AddOrderCommand>
    {
        private readonly ICarWorkshopRepository _repository;

        public AddOrderCommandHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddOrderCommand command)
        {
            var validationResult = new AddOrderCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var client = _repository.GetClientById(command.ClientId);
            if (client == null)
            {
                return Result.Fail("Client does not exist.");
            }

            var car = _repository.GetCarById(command.CarId);
            if (car == null)
            {
                return Result.Fail("Car does not exist.");
            }

            var order = new CarWorkshop.Storage.Entities.Order(command.ClientId, client, command.CarId, car, command.OrderDate, command.Status, command.Description);
            _repository.AddOrder(order);

            return Result.Ok();
        }
    }
}
