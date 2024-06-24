using CarWorkshop.Service.Command.Order.Add;
using CarWorkshop.Service.Command.Order.Edit;
using CarWorkshop.Service.Query.Order;
using CarWorkshop.Storage.Repository;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            ViewBag.ClientId = id;
            return View("Index", orders);
        }
        public IActionResult Edit(int id)
        {
            var order = _carWorkshopRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            var command = new UpdateOrderStatusCommand
            {

                OrderId = order.Id,
                CurrentStatus = order.Status,
                NewStatus = order.Status
            };

            return View(command);
        }

        [HttpPost]
        public IActionResult Edit(UpdateOrderStatusCommand command)
        {
            var handler = new UpdateOrderStatusCommandHandler(_carWorkshopRepository);
            var result = handler.Handle(command);

            if (result.IsFailure)
            {
                return View(command);
            }
            var query = new GetOrderByIdQuery(command.OrderId);
            var handler1 = new GetOrderByIdQueryHandler(_carWorkshopRepository);
            var order = handler1.Handle(query);
            int clientId = order.ClientId;

            return RedirectToAction("ClientOrders", new { id = clientId});
        }
        public IActionResult Add(int clientId)
        {
            var cars = _carWorkshopRepository.GetCarsByClientId(clientId).ToList();
            var command = new AddOrderCommand
            {
                ClientId = clientId,
                Cars = cars
            };
            return View(command);
        }

        [HttpPost]
        public IActionResult Add(AddOrderCommand command)
        {
            var handler = new AddOrderCommandHandler(_carWorkshopRepository);
            var result = handler.Handle(command);

            if (!result.IsSuccess)
            {
                var cars = _carWorkshopRepository.GetCarsByClientId(command.ClientId).ToList();
                command.Cars = cars;
                return View(command);
            }

            return RedirectToAction("ClientOrders", new { id = command.ClientId });
        }
    }
}
