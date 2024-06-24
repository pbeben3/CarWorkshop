using CarWorkshop.Service.Query.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Repair
{
    public class GetRepairsByClientIdQuery : IQuery<List<RepairDto>>
    {
        public int ClientId { get; }

        public GetRepairsByClientIdQuery(int clientId)
        {
            ClientId = clientId;
        }
    }
}
