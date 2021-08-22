using PizzaApp.Web.Models.Enums;

namespace PizzaApp.Web.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public string PizzaName { get; set; }

        public string UserFullname { get; set; }

        public double Price { get; set; }

        public string UserAddress { get; set; }
    }
}
