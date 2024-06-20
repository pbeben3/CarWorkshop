using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Storage.Entities
{
    [Table("Repairs", Schema = "CarWorkshop")]
    public class Repair
    {
        protected Repair() { }
        public Repair(int id, int orderId, Order order, DateTime repairDate, string description, int cost)
        {
            Id = id;
            OrderId = orderId;
            Order = order;
            RepairDate = repairDate;
            Description = description;
            Cost = cost;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }
        public DateTime RepairDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Cost { get; set; }

    }
}
