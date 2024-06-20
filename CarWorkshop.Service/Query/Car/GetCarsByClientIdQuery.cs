using CarWorkshop.Service.Query.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Car
{
    public class GetCarsByClientIdQuery : IQuery<List<CarDto>>
    {
        public int ClientId { get; }

        public GetCarsByClientIdQuery(int clientId)
        {
            ClientId = clientId;
        }
    }
}
