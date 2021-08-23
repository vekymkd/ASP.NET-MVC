using SEDC.PizzaApp.Web.Models.Enums;

namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class CreateOrderViewModel
    {
        public int User { get; set; }
        public int PizzaName { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string PizzaStore { get; set; }
    }
}
