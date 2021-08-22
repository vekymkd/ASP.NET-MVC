using PizzaApp.Web.Models.Domain;
using PizzaApp.Web.Models.ViewModels;

namespace PizzaApp.Web.Models.Mapper
{
    public static class OrderMapper
    {
        public static OrderDetailsViewModel OrderToOrderDetailsViewModel(Order order)
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Name,
                UserFullname = $"{order.User.FirstName} {order.User.LastName}",
                Price = order.Price * 2,
                UserAddress = order.User.Address
            };
        }
    }
}