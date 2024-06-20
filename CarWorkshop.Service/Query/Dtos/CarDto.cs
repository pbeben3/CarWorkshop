using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Dtos
{
    public class CarDto
    {
        public CarDto(int id, int clientId, string clientName, string brand, string model, int productionYear)
        {
            Id = id;
            ClientId = clientId;
            ClientName = clientName;
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
        }
        public int Id { get; }
        public int ClientId { get; }
        public string ClientName { get; }
        public string Brand { get; }
        public string Model { get; }
        public int ProductionYear { get; }
    }
}
