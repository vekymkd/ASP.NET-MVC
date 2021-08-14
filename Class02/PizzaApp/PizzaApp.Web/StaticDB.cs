using System;
using System.Collections.Generic;
using PizzaApp.Web.Models;

namespace PizzaApp.Web
{
    public class StaticDB
    {
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza
            {
                Id = 1,
                Name = "Margarita",
                IsOnPromotion = true
            },
            new Pizza
            {
                Id = 2,
                Name = "Napolitana",
                IsOnPromotion = false
            },
            new Pizza
            {
                Id = 3,
                Name = "Capri",
                IsOnPromotion = false
            }
        };
    }
}
