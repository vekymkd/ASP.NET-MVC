using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.Mapper;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            List<UserDetailsViewModel> users = new List<UserDetailsViewModel>();
            StaticDB.Users.ForEach(x => users.Add(UserMapper.UserToUserDetailsViewModel(x)));

            return View(users);
        }

        public IActionResult AddUser()
        {
            UserViewModel user = new UserViewModel();
            return View(user);
        }

        [HttpPost]
        public IActionResult AddUser(UserViewModel model)
        {
            if(model.FirstName == null || model.LastName == null || model.Adress == null || model.Phone == 0)
            {
                return View("Error");
            }

            User user = new User
            {
                Id = StaticDB.Users.Last().Id + 1,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Adress,
                Phone = model.Phone
            };

            StaticDB.Users.Add(user);
            return RedirectToAction("Index");
        }

        public IActionResult EditUser(int? id)
        {
            if (id != null)
            {
                var user = StaticDB.Users.SingleOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return View("ResourceNotFound");
                }

                var mappedUser = UserMapper.UserToUserViewModel(user);

                return View(mappedUser);
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult EditUser(UserViewModel model)
        {
            if (model.FirstName == null || model.LastName == null || model.Phone == 0 || model.Adress == null)
            {
                return View("Error");
            }

            var user = StaticDB.Users.SingleOrDefault(x => x.Id == model.Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Adress;
            user.Phone = model.Phone;

            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(int id)
        {
            if (id > 0)
            {
                var userDetails = StaticDB.Users.FirstOrDefault(x => x.Id == id);

                if (userDetails == null)
                {
                    return View("ResourceNotFound");
                }

                var mappedUser = UserMapper.UserToUserDetailsViewModel(userDetails);

                return View(mappedUser);
            }

            return View("Error");
        }

        public IActionResult DeleteUserPost(int? id)
        {
            if (id != null)
            {
                var user = StaticDB.Users.SingleOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return View("ResourceNotFound");
                }

                if (StaticDB.Orders.Any(x => x.User.Id == user.Id))
                {
                    return View("InvalidOperation");
                }

                StaticDB.Users.Remove(user);
                return RedirectToAction("Index");
            }
            return View("Error");
        }
    }
}
