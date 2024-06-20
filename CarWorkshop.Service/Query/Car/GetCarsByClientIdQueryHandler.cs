using CarWorkshop.Service.Query.Dtos;
using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Car
{
    public class GetCarsByClientIdQueryHandler :  IQueryHandler<GetCarsByClientIdQuery, List<CarDto>>
    {
        private readonly ICarWorkshopRepository _repository;

        public GetCarsByClientIdQueryHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public List<CarDto> Handle(GetCarsByClientIdQuery query)
        {
            var cars = _repository.GetCarsByClientId(query.ClientId);
            
            var carDtos = cars.Select(c => new CarDto(
                c.Id,
                c.ClientId,
                c.Client.Name + " " + c.Client.Surname,
                c.Brand,
                c.Model,
                c.ProductionYear
            )).ToList();

            return carDtos;
        }
    }
}
