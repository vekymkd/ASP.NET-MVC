using System.ComponentModel.DataAnnotations;
using SEDC.PizzaApp.Web.Models.Enums;

namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        [Display(Name = "Name of pizza")]
        public int PizzaName { get; set; }
        public string PizzaStore { get; set; }
        public bool Delivered { get; set; }
        public int UserId { get; set; }
    }
}
