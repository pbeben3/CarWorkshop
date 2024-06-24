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
        // Client
        List<Client> GetClients();
        Client GetClientById(int clientId);
        void AddClient(Client client);
        bool IsClientExist(string name, string surname, string email);
        void DeleteClient(int clientId);


        // Car
        List<Car> GetCarsByClientId(int clientId);
        Car GetCarById(int carId);
        void AddCar(Car car);
        void RemoveCar(int carId);

        // Order
        List<Order> GetOrdersByClientId(int clientId);

        Order GetOrderById(int orderId);
        void AddOrder(Order order);
        void EditOrder(Order order);

        // Repair

        List<Repair> GetRepairsByClientId(int clientId);

        Repair GetRepairById(int repairId);
        void AddRepair(Repair repair);
        void EditRepair(Repair repair);
    }
}
