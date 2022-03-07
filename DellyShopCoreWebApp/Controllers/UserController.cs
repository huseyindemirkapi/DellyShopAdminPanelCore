using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellyShop.Domain.Models;
using DellyShop.Domain.ViewModels;
using DellyShop.Repos;
using DellyShopCoreWebApp.Models;
using DellyShopCoreWebAppAdminPanel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DellyShopCoreWebAppAdminPanel.Controllers
{
    public class UserController : Controller
    {
        private RepositoryService _repo;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(RepositoryService repo, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }
        public IActionResult Index(UserViewModel viewModel)
        {
            var users = _repo.Users.GetAllUsers(viewModel.SelectedUser);

            viewModel.Users = users;

            return View(viewModel);
        }
        //public IActionResult Create()
        //{
        //    UserCreateOrEditViewModel viewModel = new UserCreateOrEditViewModel()
        //    {
        //        Action = "/Account/Register",
        //        Button = "Create",
        //        Title = "User Create",
        //        LockoutEnabled = true
        //    };

        //    return View("CreateOrEdit", viewModel);
        //}

        //[HttpPost]
        //public IActionResult Create(UserCreateOrEditViewModel viewModel)
        //{
        //    var result = _repo.Users.Create(viewModel);

        //    if (result == "OK")
        //    {
        //        return View("Info", new InfoViewModel(viewModel.FullName + " is added."));
        //    }

        //    return View("Error", new ErrorViewModel("The values you submitted are not suitable, please try again."));
        //}

        public IActionResult UpdateUser(string Id)
        {
            var result = _repo.Users.GetAllUsers(Id);

            UserCreateOrEditViewModel viewModel = new UserCreateOrEditViewModel()
            {
                Action = "/User/UpdateUser",
                Button = "Update",
                Title = "User Update",
                UserId = result.FirstOrDefault().Id,
                FirstName = result.FirstOrDefault().FirstName,
                LastName = result.FirstOrDefault().LastName,
                Email = result.FirstOrDefault().Email,
                PhoneNumber = result.FirstOrDefault().PhoneNumber,
                Password = result.FirstOrDefault().PasswordHash,
                LockoutEnabled = result.FirstOrDefault().LockoutEnabled
            };

            return View("CreateOrEdit", viewModel);
        }

        [HttpPost]
        public IActionResult UpdateUser(UserCreateOrEditViewModel viewModel)
        {
            var result = _repo.Users.Update(viewModel);

            if (result == "OK")
            {
                return View("Info", new InfoViewModel(viewModel.FullName + " is Updated."));
            }

            return View("Error", new ErrorViewModel("The values you submitted are not suitable, please try again."));
        }
        public IActionResult Delete(string Id)
        {
            var user = _repo.Users.GetAllUsers(Id);
            var result = _repo.Users.Delete(user.FirstOrDefault());

            if (result == "OK")
            {
                return View("Info", new InfoViewModel(user.FirstOrDefault().FullName + " is Deleted."));
            }

            return View("Error", new ErrorViewModel("Couldn't delete user, please try again."));
        }
    }
}
