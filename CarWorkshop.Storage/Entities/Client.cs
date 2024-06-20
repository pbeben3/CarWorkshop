using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Storage.Entities
{
    [Table("Clients", Schema = "CarWorkshop")]
    public class Client
    {
        protected Client() { }
        public Client(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Surname { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string Email { get; set; } 
        public ICollection<Car> Cars { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
