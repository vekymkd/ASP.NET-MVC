using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Models.Mapper
{
    public static class PizzaMapper
    {
        public static PizzaDetailsViewModel PizzaToPizzaDetailsViewModel (this Pizza pizza)
        {
            return new PizzaDetailsViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.HasExtras ? pizza.Price + 10 : pizza.Price,
                PizzaSize = pizza.PizzaSize,
                IsOnPromotion = pizza.IsOnPromotion
            };
        }

        public static PizzaNamesViewModel PizzaToPizzaNamesViewModel (Pizza pizza)
        {
            return new PizzaNamesViewModel
            {
                Id = pizza.Id,
                PizzaName = $"{pizza.Name} - ${pizza.Price}"
            };
        }

        public static PizzaViewModel PizzaToPizzaViewModel (Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                isOnPromotion = pizza.IsOnPromotion,
                Price = pizza.Price,
                PizzaSize = pizza.PizzaSize,
                HasExtras = pizza.HasExtras
            };
        }
    }
}
