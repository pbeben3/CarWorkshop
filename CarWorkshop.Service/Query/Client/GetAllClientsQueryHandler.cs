using CarWorkshop.Service.Query.Dtos;
using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Client
{
    public class GetAllClientsQueryHandler : IQueryHandler<GetAllClientsQuery, List<ClientDto>>
    {
        private readonly ICarWorkshopRepository _repository;

        public GetAllClientsQueryHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public List<ClientDto> Handle(GetAllClientsQuery query)
        {
            var clients = _repository.GetClients();
            var clientDtos = clients.Select(c => new ClientDto
            {
                Id = c.Id,
                Name = c.Name,
                Surname = c.Surname,
                Email = c.Email
            }).ToList();

            return clientDtos;
        }

    }
}
