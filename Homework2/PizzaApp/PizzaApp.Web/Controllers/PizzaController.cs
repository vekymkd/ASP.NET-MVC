using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using PizzaApp.Web.Models.Domain;
using PizzaApp.Web.Models.Mapper;
using PizzaApp.Web.Models.ViewModels;

namespace PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<PizzaDetailsViewModel> pizzaViewList = new List<PizzaDetailsViewModel>();

            StaticDB.Pizzas.ForEach(x => pizzaViewList.Add(x.PizzaToPizzaDetailsViewModel()));

            ViewData.Add("Title", "Details for all pizzas");

            return View(pizzaViewList);
        }

        public IActionResult Details(int id)
        {
            if (StaticDB.Pizzas.Any(x => x.Id == id))
            {
                Pizza pizza = StaticDB.Pizzas.SingleOrDefault(x => x.Id == id);

                PizzaDetailsViewModel pizzaView = pizza.PizzaToPizzaDetailsViewModel();

                ViewBag.Pizza = pizzaView;

                ViewData.Add("Title", "Details for the chosen pizza");

                return View();
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
