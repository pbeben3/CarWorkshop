using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Client.Add
{
    public sealed class AddClientCommandHandler : ICommandHandler<AddClientCommand>
    {
        private readonly ICarWorkshopRepository _repository;

        public AddClientCommandHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddClientCommand command)
        {
            var validationResult = new AddClientValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var isExist = _repository.IsClientExist(command.Name, command.Surname, command.Email);

            if (isExist)
            {
                return Result.Fail("This client already exists.");
            }

            var client = new CarWorkshop.Storage.Entities.Client(command.Name, command.Surname, command.Email);
            _repository.AddClient(client);

            return Result.Ok();
        }
    }
}
