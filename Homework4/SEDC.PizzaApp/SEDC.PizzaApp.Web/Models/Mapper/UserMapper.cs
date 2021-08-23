using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Models.Mapper
{
    public static class UserMapper
    {
        public static UserDetailsViewModel UserToUserDetailsViewModel (User user)
        {
            return new UserDetailsViewModel
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            };
        }

        public static UserViewModel UserToUserViewModel (User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Adress = user.Address,
                Phone = user.Phone
            };
        }
    }
}
