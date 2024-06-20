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
            return View(cars); 
        }
    }
}
