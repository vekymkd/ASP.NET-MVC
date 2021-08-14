using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using PizzaApp.Web.Models;

namespace PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizza> Pizzas = StaticDB.Pizzas;

            return View(Pizzas);
        }

        public IActionResult Details(int id)
        {
            if (StaticDB.Pizzas.Any(x => x.Id == id))
            {

                Pizza pizza = StaticDB.Pizzas.SingleOrDefault(x => x.Id == id);

                return View(pizza);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
