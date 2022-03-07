using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellyShop.Domain.Models;
using DellyShop.Domain.ViewModels;
using DellyShop.Repos;
using DellyShopCoreWebApp.Models;
using DellyShopCoreWebAppAdminPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace DellyShopCoreWebAppAdminPanel.Controllers
{
    public class CustomerController : Controller
    {
        private RepositoryService _repo;
        public CustomerController(RepositoryService repo)
        {
            _repo = repo;
        }
        public IActionResult Index(CustomerIndexViewModel viewModel)
        {
            List<Customer> customers = _repo.Customers.GetCustomers();
            viewModel.Customers = customers;

            return View(viewModel);
        }

        public IActionResult Edit(Guid Id)
        {
            Customer customer = _repo.Customers.GetCustomerById(Id);

            CustomerCreateOrEditViewModel viewModel = new CustomerCreateOrEditViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Password = customer.Password,
                IsActive = customer.IsActive,
                Action = "/Customer/Edit",
                Button = "Edit",
                Title = "Customer Edit",
            };

            return View("CreateOrEdit", viewModel);
        }
        [HttpPost]
        public IActionResult Edit(CustomerCreateOrEditViewModel viewModel)
        {

            var result = _repo.Customers.CustomerUpdate(viewModel);

            if (result == "OK")
            {
                return View("Info", new InfoViewModel(viewModel.Name + " " + viewModel.Surname + " is Edited"));
            }

            return View("Error", new ErrorViewModel("Couldn't edit customer, please try again."));
        }
        public IActionResult Create()
        {

            CustomerCreateOrEditViewModel viewModel = new CustomerCreateOrEditViewModel()
            {

                Action = "Create",
                Button = "Create",
                Title = "Customer Create",
                IsActive = true
            };

            return View("CreateOrEdit", viewModel);
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateOrEditViewModel viewModel)
        {
            var result = _repo.Customers.CustomerCreate(viewModel);

            if (result == "OK")
            {
                return View("Info", new InfoViewModel(viewModel.Name + " " + viewModel.Surname + " is Added"));
            }

            return View("Error", new ErrorViewModel("Could't add customer , please try again."));
        }

        public IActionResult Delete(Guid id)
        {
            var customer = _repo.Customers.GetCustomerById(id);
            var result = _repo.Customers.Delete(customer);

            if (result == "OK")
            {
                return View("Info", new InfoViewModel(customer.Name +" "+ customer.Surname + " is deleted"));
            }

            return View("Error", new ErrorViewModel("Couldn't delete Customer, please try again."));

        }
    }
}
