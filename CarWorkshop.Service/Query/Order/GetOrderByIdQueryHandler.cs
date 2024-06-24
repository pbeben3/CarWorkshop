using CarWorkshop.Service.Query.Dtos;
using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Order
{
    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly ICarWorkshopRepository _repository;

        public GetOrderByIdQueryHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }
        public OrderDto Handle(GetOrderByIdQuery query)
        {
            var order = _repository.GetOrderById(query.OrderId);

            var orderDto = new OrderDto(
                order.Id,
                order.ClientId,
                $"{order.Client.Name} {order.Client.Surname}",
                order.CarId,
                order.Car.Brand,
                order.Car.Model,
                order.OrderDate,
                order.Status,
                order.Description
            );

            return orderDto;


        }
    }
}
