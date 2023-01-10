using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApplicationTest.Database;
using WebApplicationTest.Models;
using WebApplicationTest.Utilities;

namespace WebApplicationTest.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> listaPizze = db.Pizzas.ToList();
                return View("Index", listaPizze);
            }
        }

        public IActionResult Details(int id)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaDaCercare = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDaCercare != null)
                {
                    return View(pizzaDaCercare);
                }

                return NotFound("Something went wrong tralalala");
            }

        }

        [HttpGet]
        public IActionResult GenerateForm()
        {
            return View("GenerateForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GenerateForm(Pizza formData)
        {
            if(!ModelState.IsValid)
            {
                return View("GenerateForm", formData);
            }

            using(PizzeriaContext db = new PizzeriaContext())
            {
                db.Pizzas.Add(formData);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
