using AllariNet.Interfaces;
using AllariNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AllariNet.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IPersonService _personService;

        public IActionResult GetPersons()
        {
            var persons = _personService.GetPersons();
            return Json(persons);
        }

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            var persons = _personService.GetPersons();

            return View(persons);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}