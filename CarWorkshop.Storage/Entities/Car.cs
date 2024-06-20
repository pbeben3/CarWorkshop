using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Storage.Entities
{
    [Table("Cars", Schema = "CarWorkshop")]
    public class Car
    {
        protected Car() { }
        public Car(int clientId, Client client, string brand, string model, int productionyear)
        {
            ClientId = clientId;
            Client = client;
            Brand = brand;
            Model = model;
            ProductionYear = productionyear;
        }


        [Required]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public virtual Client Client { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public int ProductionYear { get; set; }

    }
}
