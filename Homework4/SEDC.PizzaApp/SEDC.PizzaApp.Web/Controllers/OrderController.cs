using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.Mapper;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> orders = StaticDB.Orders;

            List<OrderDetailsViewModel> orderDetailsViews = new List<OrderDetailsViewModel>();

            foreach(Order order in orders)
            {
                orderDetailsViews.Add(OrderMapper.OrderToOrderDetailsViewModel(order));
            }

            return View(orderDetailsViews);
        }

        public IActionResult Details(int id)
        {
            if(id > 0)
            {
                var orderDetails = StaticDB.Orders.FirstOrDefault(x => x.Id == id);

                if(orderDetails == null)
                {
                    return View("ResourceNotFound");
                }

                var mappedModel = OrderMapper.OrderToOrderDetailsViewModel(orderDetails);

                ViewData.Add("OrderDetails", mappedModel);

                return View(mappedModel);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult DeleteOrder(int id)
        {
            if(id > 0)
            {
                var orderDetails = StaticDB.Orders.FirstOrDefault(x => x.Id == id);

                if(orderDetails == null)
                {
                    return View("ResourceNotFound");
                }

                var mappedOrder = OrderMapper.OrderToOrderDetailsViewModel(orderDetails);

                return View(mappedOrder);
            }

            return View("Error");
        }

        public IActionResult DeleteOrderPost(int? id)
        {
            if(id != null)
            {
                var order = StaticDB.Orders.SingleOrDefault(x => x.Id == id);
                if(order == null)
                {
                    return View("ResourceNotFound");
                }

                StaticDB.Orders.Remove(order);
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        public IActionResult EditOrder(int? id)
        {
            if (id != null)
            {
                var order = StaticDB.Orders.SingleOrDefault(x => x.Id == id);
                if (order == null)
                {
                    return View("ResourceNotFound");
                }

                var mappedOrder = OrderMapper.OrderToOrderViewModel(order);

                ViewBag.Users = StaticDB.Users.Select(x => UserMapper.UserToUserDetailsViewModel(x));
                ViewBag.Pizzas = StaticDB.Pizzas.Select(x => PizzaMapper.PizzaToPizzaNamesViewModel(x));

                return View(mappedOrder);
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult EditOrder(OrderViewModel model)
        {
            if(model.PizzaStore == null)
            {
                return View("Error");
            }
            Order order = StaticDB.Orders.SingleOrDefault(x => x.Id == model.Id);
            order.User = StaticDB.Users.SingleOrDefault(x => x.Id == model.UserId);
            order.Price = StaticDB.Pizzas.SingleOrDefault(x => x.Id == model.PizzaName).Price;
            order.Pizza = StaticDB.Pizzas.SingleOrDefault(x => x.Id == model.PizzaName);
            order.PaymentMethod = model.PaymentMethod;
            order.Delivered = model.Delivered;
            order.PizzaStore = model.PizzaStore;

            return RedirectToAction("Index");
        }

        public IActionResult CreateOrder()
        {
            CreateOrderViewModel order = new CreateOrderViewModel();
            ViewBag.Users = StaticDB.Users.Select(x => UserMapper.UserToUserDetailsViewModel(x));
            ViewBag.Pizzas = StaticDB.Pizzas.Select(x => PizzaMapper.PizzaToPizzaNamesViewModel(x));

            return View(order);
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderViewModel model)
        {
            if (model.PizzaStore == null || model.PaymentMethod == 0 ||
                StaticDB.Users.SingleOrDefault(x => x.Id == model.User) == null ||
                StaticDB.Pizzas.SingleOrDefault(x => x.Id == model.PizzaName) == null)
            {
                return View("Error");
            }

            Order order = new Order
            {
                Id = StaticDB.Orders.Last().Id + 1,
                User = StaticDB.Users.SingleOrDefault(x => x.Id == model.User),
                Price = StaticDB.Pizzas.SingleOrDefault(x => x.Id == model.PizzaName).Price,
                Pizza = StaticDB.Pizzas.SingleOrDefault(x => x.Id == model.PizzaName),
                PaymentMethod = model.PaymentMethod,
                Delivered = false,
                PizzaStore = model.PizzaStore
            };

            StaticDB.Orders.Add(order);
            return RedirectToAction("Index");
        }
    }
}
