using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Repair.Add
{
    public sealed class AddRepairCommand : ICommand
    {
        public int OrderId { get; set; }
        public DateTime RepairDate { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
    }
}
