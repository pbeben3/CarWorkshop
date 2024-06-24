using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Client.Delete
{
    public class DeleteClientCommandHandler : ICommandHandler<DeleteClientCommand>
    {
        private readonly ICarWorkshopRepository _repository;

        public DeleteClientCommandHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(DeleteClientCommand command)
        {
            var client = _repository.GetClientById(command.ClientId);
            if (client == null)
            {
                return Result.Fail("Client doesnt exist.");
            }

            _repository.DeleteClient(command.ClientId);

            return Result.Ok();
        }
    }
}
