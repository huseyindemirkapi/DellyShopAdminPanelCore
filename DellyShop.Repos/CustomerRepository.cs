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
    public class CustomerRepository
    {
        private ApplicationDbContext _Db;
        private readonly DbSet<Customer> _Customer;

        public CustomerRepository(ApplicationDbContext db)
        {
            _Db = db;
            _Customer = _Db.Customers;
        }

        public List<Customer> GetCustomers()
        {
            var query = _Customer
               .Include(x => x.Comments)
               .Where(x => x.IsActive == true)
               .AsQueryable();

            return query.ToList();
        }

        public Customer GetCustomerById(Guid Id)
        {
            return _Customer
                .Where(x => x.Id == Id && x.IsActive == true)
                .FirstOrDefault();
        }
        public string CustomerUpdate(CustomerCreateOrEditViewModel viewModel)
        {
            Customer customer = GetCustomerById(viewModel.Id);

            customer.Name = viewModel.Name;
            customer.Surname = viewModel.Surname;
            customer.Email = viewModel.Email;
            customer.PhoneNumber = viewModel.PhoneNumber;
            customer.Password = viewModel.Password;
            customer.IsActive = viewModel.IsActive;

            try
            {
                _Db.SaveChanges();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "OK";
        }
        public string CustomerCreate(CustomerCreateOrEditViewModel viewModel)
        {
            Customer customer = new Customer()
            {
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Password = viewModel.Password,
                PasswordConfirm = viewModel.Password,
                IsActive = viewModel.IsActive
            };

            try
            {
                _Customer.Add(customer);
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "OK";
        }
        public string Delete(Customer customer)
        {
            customer.IsActive = false;

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
