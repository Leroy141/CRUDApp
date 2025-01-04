using CRUDApp.Data.Interfaces;
using CRUDApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public HomeController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var gamesData = _gameRepository.GetAll().Result;

            var viewModel = gamesData.Select(game => new GameViewModel()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Price = game.Price,
            }).ToList();

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _gameRepository.Delete(id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(Guid id, string name, string description, decimal price)
        {
            _gameRepository.Update(id, name, description, price);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(string name, string description, decimal price)
        {
            _gameRepository.Create(Guid.NewGuid(), name, description, price);

            return RedirectToAction("Index");
        }
    }
}
