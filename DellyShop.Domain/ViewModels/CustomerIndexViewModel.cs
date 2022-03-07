using DellyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.ViewModels
{
    public class CustomerIndexViewModel
    {
        public List<Customer> Customers { get; set; }

        public int SelectedCustomer { get; set; }
    }
}
