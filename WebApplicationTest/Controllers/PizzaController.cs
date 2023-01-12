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

        [HttpGet]
        public IActionResult Update(int id)
        {
            using(PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaToUpdate = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToUpdate != null)
                {
                    return View("Update", pizzaToUpdate);
                }

                return NotFound("Something went wrong when trying to update this pizza");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Pizza pizzaFormInfo)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", pizzaFormInfo);
            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaToUpdate = db.Pizzas.Where(pizza => pizza.Id == pizzaFormInfo.Id).FirstOrDefault();

                if (pizzaToUpdate != null)
                {
                    pizzaToUpdate.Name = pizzaFormInfo.Name;
                    pizzaToUpdate.Description = pizzaFormInfo.Description;
                    pizzaToUpdate.Image = pizzaFormInfo.Image;
                    pizzaToUpdate.Price = pizzaFormInfo.Price;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("haha pizza goes brrr");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using(PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaToDelete = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToDelete != null)
                {
                    db.Pizzas.Remove(pizzaToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("why are we here, just to suffer");
                }
            }
        }
    }
}
