using CarWorkshop.Service.Query.Dtos;
using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Order
{
    public class GetOrdersByClientIdQueryHandler : IQueryHandler<GetOrdersByClientIdQuery, List<OrderDto>>
    {
        private readonly ICarWorkshopRepository _repository;

        public GetOrdersByClientIdQueryHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public List<OrderDto> Handle(GetOrdersByClientIdQuery query)
        {
            var orders = _repository.GetOrdersByClientId(query.ClientId);
            var orderDtos = orders.Select(o => new OrderDto(
                o.Id,
                o.ClientId,
                o.Client.Name + " " + o.Client.Surname,
                o.CarId,
                o.Car.Brand,
                o.Car.Model,
                o.OrderDate,
                o.Status,
                o.Description
            )).ToList();

            return orderDtos;
        }
    }
}
