using CarWorkshop.Service.Query.Order;
using CarWorkshop.Storage.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;

        public OrdersController(ICarWorkshopRepository repository)
        {
            _carWorkshopRepository = repository;
        }


        public IActionResult ClientOrders(int id)
        {
            var handler = new GetOrdersByClientIdQueryHandler(_carWorkshopRepository);
            var query = new GetOrdersByClientIdQuery(id);
            var orders = handler.Handle(query);
            return View("Index", orders);
        }
    }
}
