using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Order.Edit
{
    public class UpdateOrderStatusCommand : ICommand
    {
        public int OrderId { get; set; }
        public string CurrentStatus { get; set; }

        public string NewStatus { get; set; }


    }
}
