using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Car.Add
{
    public sealed class AddCarCommandHandler : ICommandHandler<AddCarCommand>
    {
        private readonly ICarWorkshopRepository _repository;

        public AddCarCommandHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddCarCommand command)
        {
            var validationResult = new AddCarCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }


            var car = new CarWorkshop.Storage.Entities.Car(command.ClientId, null, command.Brand, command.Model, command.ProductionYear);
            _repository.AddCar(car);

            return Result.Ok();
        }
    }
}
