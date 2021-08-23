using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Models.Mapper
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
                UserAddress = order.User.Address,
                Delivered = order.Delivered,
                PizzaStore = order.PizzaStore
            };
        }

        public static OrderViewModel OrderToOrderViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Id,
                PizzaStore = order.PizzaStore,
                Delivered = order.Delivered,
                UserId = order.User.Id
            };
        }
    }
}
