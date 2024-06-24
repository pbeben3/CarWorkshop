using CarWorkshop.Service.Command.Repair.Add;
using CarWorkshop.Service.Query.Dtos;
using CarWorkshop.Service.Query.Order;
using CarWorkshop.Service.Query.Repair;
using CarWorkshop.Storage.Entities;
using CarWorkshop.Storage.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Controllers
{
    public class RepairsController : Controller
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;

        public RepairsController(ICarWorkshopRepository repository)
        {
            _carWorkshopRepository = repository;
        }

        public IActionResult Add(int orderId)
        {
            var command = new AddRepairCommand { OrderId = orderId };
            return View(command);
        }

        [HttpPost]
        public IActionResult Add(AddRepairCommand command)
        {
            var handler = new AddRepairCommandHandler(_carWorkshopRepository);
            var result = handler.Handle(command);

            if (result.IsFailure)
            {
                return View(command);
            }
            var query = new GetOrderByIdQuery(command.OrderId);
            var handler1 = new GetOrderByIdQueryHandler(_carWorkshopRepository);
            var order = handler1.Handle(query);
            int clientId = order.ClientId;



            return RedirectToAction("ClientOrders", "Orders", new { id = clientId });


        }

        public IActionResult Index(int id)
        {
            var handler = new GetRepairsByClientIdQueryHandler(_carWorkshopRepository);
            var query = new GetRepairsByClientIdQuery(id);
            var repairs = handler.Handle(query);
            return View(repairs);
        }
    }
}
