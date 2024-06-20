using CarWorkshop.Service.Query.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Order
{
    public class GetOrdersByClientIdQuery : IQuery<List<OrderDto>>
    {
        public int ClientId { get; }

        public GetOrdersByClientIdQuery(int clientId)
        {
            ClientId = clientId;
        }
    }
}
