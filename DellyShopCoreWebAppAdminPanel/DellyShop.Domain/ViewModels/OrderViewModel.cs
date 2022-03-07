using DellyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.ViewModels
{
    public class OrderViewModel
    {
        public List<Order> Orders { get; set; }

        public List<Customer> Customers { get; set; }

        public Guid SelectedCustomer { get; set; }
    }
}
