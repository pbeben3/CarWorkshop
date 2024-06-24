using CarWorkshop.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Storage.Repository
{
    public class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _context;

        public CarWorkshopRepository(CarWorkshopDbContext context)
        {
            _context = context;
        }

        // Client
        public List<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetClientById(int clientId)
        {
            return _context.Clients
                .Include(c => c.Cars)
                .Include(c => c.Orders)
                .SingleOrDefault(c => c.Id == clientId);
        }

        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public bool IsClientExist(string name, string surname, string email)
        {
            return _context.Clients.Any(c =>
                c.Name == name &&
                c.Surname == surname &&
                c.Email == email);
        }
        public void DeleteClient(int clientId)
        {
            var client = _context.Clients
                .Include(c => c.Cars)
                .Include(c => c.Orders)
                .ThenInclude(o => o.Repair)
                .SingleOrDefault(c => c.Id == clientId);

            if (client != null)
            {
                foreach (var order in client.Orders)
                {
                    _context.Repairs.RemoveRange(order.Repair);
                }

                _context.Orders.RemoveRange(client.Orders);

                _context.Cars.RemoveRange(client.Cars);

                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }

            // Car
            public List<Car> GetCarsByClientId(int clientId)
        {
            return _context.Cars
                .Include(c => c.Client) 
                .Where(c => c.ClientId == clientId)
                .ToList();
        }
 

        public Car GetCarById(int carId)
        {
            return _context.Cars
                .Include(c => c.Client)
                .SingleOrDefault(c => c.Id == carId);
        }

        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void RemoveCar(int carId)
        {
            var car = _context.Cars.Find(carId);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }

        // Order

        public Order GetOrderById(int orderId)
        {
            return _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Car)
                .Include(o => o.Repair)
                .SingleOrDefault(o => o.Id == orderId);
        }
        public List<Order> GetOrdersByClientId(int clientId)
        {
            return _context.Orders
                .Include(o => o.Car)
                .Include(o => o.Client)
                .Include(o => o.Repair)
                .Where(o => o.ClientId == clientId)
                .ToList();
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void EditOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }


        // Repair

        public Repair GetRepairById(int repairId)
        {
            return _context.Repairs
                .Include(r => r.Order)
                .SingleOrDefault(r => r.Id == repairId);
        }
        public List<Repair> GetRepairsByClientId(int clientId)
        {

            return _context.Repairs
                .Include(r => r.Order)
                    .ThenInclude(o => o.Client)
                .Include(r => r.Order)
                    .ThenInclude(o => o.Car)
                .Where(r => r.Order != null && r.Order.ClientId == clientId)
                .ToList();
        }
        public void AddRepair(Repair repair)
        {
            _context.Repairs.Add(repair);
            _context.SaveChanges();
        }

        public void EditRepair(Repair repair)
        {
            _context.Repairs.Update(repair);
            _context.SaveChanges();
        }

    }
}
