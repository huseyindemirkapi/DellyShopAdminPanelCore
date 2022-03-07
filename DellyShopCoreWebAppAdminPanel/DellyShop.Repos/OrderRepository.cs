using DellyShop.Data;
using DellyShop.Domain.Models;
using DellyShop.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DellyShop.Repos
{
    public class OrderRepository
    {
        private ApplicationDbContext _Db;
        private readonly DbSet<Order> _Orders;

        public OrderRepository(ApplicationDbContext db)
        {
            _Db = db;
            _Orders = _Db.Orders;
        }

        public List<Order> GetAllOrders(Guid customerId)
        {
            var query = _Orders
                .Include(x => x.Customer)
                .Where(y => y.IsActive == true)
                .AsQueryable();

            if (customerId != Guid.Empty)
            {
                query = query.Where(x => x.Customer.Id == customerId);
            }

            query = query.OrderByDescending(x => x.CreatedOn);

            return query.ToList();
        }

        public Order GetOrderById(int Id)
        {
            return _Orders
                .Include(x => x.Customer)
                .Include(y => y.ProductOrderMany)
                .Where(x => x.Id == Id && x.IsActive == true)
                .OrderByDescending(x => x.CreatedOn)
                .FirstOrDefault();

        }
        public string Update(OrderEditViewModel viewModel)
        {
            Order order = GetOrderById(viewModel.Id);

            order.Id = viewModel.Id;
            order.Description = viewModel.Description;
            order.Customer = viewModel.Customer;
            order.OrderState = viewModel.OrderState;
            order.ShippingCostPrice = viewModel.ShippingCostPrice;
            order.TotalPrice = viewModel.TotalPrice;
            order.IsActive = viewModel.IsActive;

            try
            {
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return "OK";
        }

        public string Delete(int id)
        {
            var order = GetOrderById(id);
            order.IsActive = false;

            try
            {
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return "OK";
        }
    }
}
