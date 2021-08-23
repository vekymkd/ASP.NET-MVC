using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.Mapper;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<PizzaDetailsViewModel> pizzaViewList = new List<PizzaDetailsViewModel>();

            StaticDB.Pizzas.ForEach(x => pizzaViewList.Add(x.PizzaToPizzaDetailsViewModel()));

            ViewData.Add("Title", "Pizzas");
            return View(pizzaViewList);
        }

        public IActionResult Details(int id)
        {
            if (StaticDB.Pizzas.Any(x => x.Id == id))
            {
                Pizza pizza = StaticDB.Pizzas.SingleOrDefault(x => x.Id == id);
                PizzaDetailsViewModel pizzaView = pizza.PizzaToPizzaDetailsViewModel();

                ViewData.Add("Title", "Details for the chosen pizza");
                return View(pizzaView);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult EditPizza (int? id)
        {
            if (id != null)
            {
                var pizza = StaticDB.Pizzas.SingleOrDefault(x => x.Id == id);
                if (pizza == null)
                {
                    return View("ResourceNotFound");
                }

                var mappedPizza = PizzaMapper.PizzaToPizzaViewModel(pizza);

                return View(mappedPizza);
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult EditPizza(PizzaViewModel model)
        {
            if (model.Name == null || model.Price <= 0)
            {
                return View("Error");
            }

            var pizza = StaticDB.Pizzas.SingleOrDefault(x => x.Id == model.Id);
            pizza.Name = model.Name;
            pizza.IsOnPromotion = model.isOnPromotion;
            pizza.Price = model.Price;
            pizza.PizzaSize = model.PizzaSize;
            pizza.HasExtras = model.HasExtras;
            
            return RedirectToAction("Index");
        }

        public IActionResult AddPizza()
        {
            PizzaViewModel pizza = new PizzaViewModel();
            return View(pizza);
        }

        [HttpPost]
        public IActionResult AddPizza(PizzaViewModel model)
        {
            if(model.Name == null || model.Price <= 0)
            {
                return View("Error");
            }

            var pizza = new Pizza
            {
                Id = StaticDB.Pizzas.Last().Id + 1,
                Name = model.Name,
                IsOnPromotion = model.isOnPromotion,
                Price = model.Price,
                PizzaSize = model.PizzaSize,
                HasExtras = model.HasExtras
            };

            StaticDB.Pizzas.Add(pizza);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePizza(int id)
        {
            if (id > 0)
            {
                var pizzaDetails = StaticDB.Pizzas.FirstOrDefault(x => x.Id == id);

                if (pizzaDetails == null)
                {
                    return View("ResourceNotFound");
                }

                var mappedOrder = PizzaMapper.PizzaToPizzaDetailsViewModel(pizzaDetails);

                return View(mappedOrder);
            }
            return View("Error");
        }

        public IActionResult DeletePizzaPost(int? id)
        {
            if (id != null)
            {
                var pizza = StaticDB.Pizzas.SingleOrDefault(x => x.Id == id);
                if (pizza == null)
                {
                    return View("ResourceNotFound");
                }

                if(StaticDB.Orders.Any(x => x.Pizza.Id == pizza.Id))
                {
                    return View("InvalidOperation");
                }

                StaticDB.Pizzas.Remove(pizza);
                return RedirectToAction("Index");
            }
            return View("Error");
        }
    }
}
