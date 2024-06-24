using CarWorkshop.Service.Query.Dtos;
using CarWorkshop.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Repair
{
    public class GetRepairsByClientIdQueryHandler : IQueryHandler<GetRepairsByClientIdQuery, List<RepairDto>>
    {
        private readonly ICarWorkshopRepository _repository;

        public GetRepairsByClientIdQueryHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public List<RepairDto> Handle(GetRepairsByClientIdQuery query)
        {
            var repairs = _repository.GetRepairsByClientId(query.ClientId);
            var repairDtos = repairs
                .Where(r => r.Order != null && r.Order.Client != null && r.Order.Car != null) 
                .Select(r => new RepairDto(
                    r.Id,
                    r.OrderId,
                    r.Order.ClientId,
                    r.Order.Client.Name + " " + r.Order.Client.Surname,
                    r.Order.CarId,
                    r.Order.Car.Brand,
                    r.Order.Car.Model,
                    r.RepairDate,
                    r.Description,
                    r.Cost
                )).ToList();

            return repairDtos;
        }
    }
}
