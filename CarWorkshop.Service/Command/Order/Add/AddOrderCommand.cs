using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Order.Add
{
    public sealed class AddOrderCommand : ICommand
    {
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public List<CarWorkshop.Storage.Entities.Car> Cars { get; set; } 
    }
}
