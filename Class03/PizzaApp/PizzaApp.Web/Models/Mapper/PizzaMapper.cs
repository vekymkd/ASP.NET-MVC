using PizzaApp.Web.Models.Domain;
using PizzaApp.Web.Models.ViewModels;

namespace PizzaApp.Web.Models.Mapper
{
    public static class PizzaMapper
    {
        public static PizzaDetailsViewModel PizzaToPizzaDetailsViewModel(this Pizza pizza)
        {
            return new PizzaDetailsViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.HasExtras == true ? pizza.Price += 10 : pizza.Price,
                PizzaSize = pizza.PizzaSize
            };
        }
    }
}
