using CarWorkshop.Service.Command.Car.Add;
using CarWorkshop.Service.Query.Car;
using CarWorkshop.Storage.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;

        public CarsController(ICarWorkshopRepository repository)
        {
            _carWorkshopRepository = repository;
        }

        public IActionResult ClientCars(int id)
        {
            var handler = new GetCarsByClientIdQueryHandler(_carWorkshopRepository);
            var query = new GetCarsByClientIdQuery(id);
            var cars = handler.Handle(query);
            ViewBag.ClientId = id;
            return View("Index",cars); 
        }
        public IActionResult Add(int clientId)
        {
            var command = new AddCarCommand { ClientId = clientId };
            return View(command);
        }

        [HttpPost]
        public IActionResult Add(AddCarCommand command)
        {


            var handler = new AddCarCommandHandler(_carWorkshopRepository);
            var result = handler.Handle(command);

            if (result.IsFailure)
            {
                return View(command); 
            }

            return RedirectToAction("ClientCars", new { id = command.ClientId });
        }
    }

}

