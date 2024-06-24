using CarWorkshop.Service.Query.Client;
using CarWorkshop.Service.Query.Dtos;
using CarWorkshop.Service.Query;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Service.Command.Client.Add;
using CarWorkshop.Service;
using CarWorkshop.Storage.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CarWorkshop.Service.Command.Client.Delete;

namespace CarWorkshop.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;


        public ClientsController(ICarWorkshopRepository repository)
        {
            _carWorkshopRepository = repository;
        }

        public IActionResult Index()
        {
            var handler = new GetAllClientsQueryHandler(_carWorkshopRepository);
            var query = new GetAllClientsQuery();
            var clients = handler.Handle(query);
            return View(clients);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddClientCommand command)
        {
            var handler = new AddClientCommandHandler(_carWorkshopRepository);
            var result = handler.Handle(command);
            if (result.IsFailure)
                return View(command);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(DeleteClientCommand command)
        {
            var handler = new DeleteClientCommandHandler(_carWorkshopRepository);
            var result = handler.Handle(command);

            if (result.IsFailure)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");



        }
    }
}
