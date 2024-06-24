using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Dtos
{
    public class RepairDto
    {
        public RepairDto(int id, int orderId, int clientId, string clientName, int carId, string carBrand, string carModel, DateTime repairDate, string description, int cost)
        {
            Id = id;
            OrderId = orderId;
            ClientId = clientId;
            ClientName = clientName;
            CarId = carId;
            CarBrand = carBrand;
            CarModel = carModel;
            RepairDate = repairDate;
            Description = description;
            Cost = cost;
        }

        public int Id { get; }
        public int OrderId { get; }
        public int ClientId { get; }
        public string ClientName { get; }
        public int CarId { get; }
        public string CarBrand { get; }
        public string CarModel { get; }
        public DateTime RepairDate { get; }
        public string Description { get; }
        public int Cost { get; }
    }
}

