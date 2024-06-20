using CarWorkshop.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Storage.Repository
{
    public interface ICarWorkshopRepository
    {
        List<Client> GetClients();
        Client GetClientById(int clientId);
        void AddClient(Client client);
        void EditClient(Client client);
        void RemoveClient(int clientId);
        bool IsClientExist(string name, string surname, string email);


        // Metody dla samochodów
        List<Car> GetCars();
        List<Car> GetCarsByClientId(int clientId);
        Car GetCarById(int carId);
        void AddCar(Car car);
        void EditCar(Car car);
        void RemoveCar(int carId);

        // Metody dla zamówień
        List<Order> GetOrders();
        List<Order> GetOrdersByClientId(int clientId);

        Order GetOrderById(int orderId);
        void AddOrder(Order order);
        void EditOrder(Order order);
        void RemoveOrder(int orderId);

        // Metody dla napraw
        List<Repair> GetRepairs();
        Repair GetRepairById(int repairId);
        void AddRepair(Repair repair);
        void EditRepair(Repair repair);
        void RemoveRepair(int repairId);
    }
}
