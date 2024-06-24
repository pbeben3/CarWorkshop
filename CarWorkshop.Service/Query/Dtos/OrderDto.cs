using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Query.Dtos
{
    public class OrderDto
    {
        public OrderDto(int id, int clientId, string clientName, int carId, string carBrand, string carModel, DateTime orderDate, string status, string description)
        {
            Id = id;
            ClientId = clientId;
            ClientName = clientName;
            CarId = carId;
            CarBrand = carBrand;
            CarModel = carModel;
            OrderDate = orderDate;
            Status = status;
            Description = description;
        }

        public int Id { get;  }
        public int ClientId { get;  }
        public string ClientName { get;  }
        public int CarId { get;  }
        public string CarBrand { get;  }
        public string CarModel { get;  }
        public DateTime OrderDate { get;  }
        public string Status { get;  }
        public string Description { get;  }
    }
}
