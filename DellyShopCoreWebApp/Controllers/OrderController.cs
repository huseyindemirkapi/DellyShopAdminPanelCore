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
    public class OrderController : Controller
    {
        private RepositoryService _repo;
        public OrderController(RepositoryService repo)
        {
            _repo = repo;
        }
        public IActionResult Index(OrderViewModel viewModel)
        {
            List<Order> orders = _repo.Orders.GetAllOrders(viewModel.SelectedCustomer);
            List<Customer> customers = _repo.Customers.GetCustomers();

            viewModel.Orders = orders;
            viewModel.Customers = customers;

            return View(viewModel);
        }
        public IActionResult Update(int Id)
        {
            Order order = _repo.Orders.GetOrderById(Id);

            OrderEditViewModel viewModel = new OrderEditViewModel()
            {
                Id = order.Id,
                Description = order.Description,
                Customer = order.Customer,
                OrderState = order.OrderState,
                ShippingCostPrice = order.ShippingCostPrice,
                TotalPrice = order.TotalPrice,
                ProductOrderMany = order.ProductOrderMany
            };

            return View("Edit", viewModel);
        }
        [HttpPost]
        public IActionResult Update(OrderEditViewModel viewModel)
        {
            
            var result = _repo.Orders.Update(viewModel);

            if (result == "OK")
            {
                return View("Info", new InfoViewModel( "Order Id =" + viewModel.Id +  "is Edited"));
            }

            return View("Error", new ErrorViewModel("Couldn't edit Order, please try again."));
        }
        public IActionResult Delete(int id)
        {
            var result = _repo.Orders.Delete(id);

            if (result == "OK")
            {
                return View("Info", new InfoViewModel("Order Id =" + id + " is deleted"));
            }

            return View("Error", new ErrorViewModel("Couldn't delete Order, please try again."));
        }
    }
}
