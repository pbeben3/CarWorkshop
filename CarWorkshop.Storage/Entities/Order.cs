using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Storage.Entities
{
    [Table("Orders", Schema = "CarWorkshop")]
    public class Order
    {
        protected Order() { }
        public Order(int clientId, Client client, int carId, Car car, DateTime orderDate, string status, string description)
        {
            ClientId = clientId;
            Client = client;
            CarId = carId;
            Car = car;
            OrderDate = orderDate;
            Status = status;
            Description = description;
        }


        [Required]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public Client Client { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public Car Car { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Repair> Repair { get; set; }
    }
}
