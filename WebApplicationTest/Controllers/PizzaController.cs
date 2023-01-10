using Microsoft.AspNetCore.Mvc;
using WebApplicationTest.Models;
using WebApplicationTest.Utilities;

namespace WebApplicationTest.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizza> pizzaList = PizzaData.ConstructPizzas();

            return View("Index", pizzaList);
        }

        public IActionResult Details(int id)
        {
            List<Pizza> pizzaList = PizzaData.ConstructPizzas();

            foreach(Pizza element in pizzaList)
            {
                if(element.Id == id)
                {
                    return View(element);
                }
            }

            return NotFound("Something went wrong tralalala");
        }
    }
}
