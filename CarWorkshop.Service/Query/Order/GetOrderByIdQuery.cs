using CarWorkshop.Service.Query.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Order
{
    public class GetOrderByIdQuery : IQuery<OrderDto>
    {
        public int OrderId { get; set; }
        public GetOrderByIdQuery(int orderId) 
        { 
            OrderId = orderId;
        }
    }
}
