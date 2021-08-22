using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PizzaApp.Web.Models.Domain;
using PizzaApp.Web.Models.Mapper;
using PizzaApp.Web.Models.ViewModels;

namespace PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> orders = StaticDB.Orders;

            List<OrderDetailsViewModel> orderDetailsViews = new List<OrderDetailsViewModel>();

            foreach (Order order in orders)
            {
                orderDetailsViews.Add(OrderMapper.OrderToOrderDetailsViewModel(order));
            }

            return View(orderDetailsViews);
        }
    }
}
