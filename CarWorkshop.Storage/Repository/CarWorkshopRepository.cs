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

        // Metody dla klientów
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

        public void EditClient(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public void RemoveClient(int clientId)
        {
            var client = _context.Clients.Find(clientId);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }
        public bool IsClientExist(string name, string surname, string email)
        {
            return _context.Clients.Any(c =>
                c.Name == name &&
                c.Surname == surname &&
                c.Email == email);
        }

        // Metody dla samochodów
        public List<Car> GetCars()
        {
            return _context.Cars.ToList();
        }
        public List<Car> GetCarsByClientId(int clientId)
        {
            return _context.Cars
                .Include(c => c.Client) // Załaduj powiązanego klienta
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

        public void EditCar(Car car)
        {
            _context.Cars.Update(car);
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

        // Metody dla zamówień
        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

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

        public void RemoveOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        // Metody dla napraw
        public List<Repair> GetRepairs()
        {
            return _context.Repairs.ToList();
        }

        public Repair GetRepairById(int repairId)
        {
            return _context.Repairs
                .Include(r => r.Order)
                .SingleOrDefault(r => r.Id == repairId);
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

        public void RemoveRepair(int repairId)
        {
            var repair = _context.Repairs.Find(repairId);
            if (repair != null)
            {
                _context.Repairs.Remove(repair);
                _context.SaveChanges();
            }
        }
    }
}
