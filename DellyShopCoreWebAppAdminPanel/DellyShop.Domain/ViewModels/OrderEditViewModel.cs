using DellyShop.Domain.Enums;
using DellyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.ViewModels
{
    public class OrderEditViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int OrderCount { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal ShippingCostPrice { get; set; }

        public DateTime CreatedOn { get; set; }
        public OrderState OrderState { get; set; }

        public bool IsActive { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<ProductOrderMany> ProductOrderMany { get; set; }

        public int SelectedProduct { get; set; }

        public OrderEditViewModel()
        {
            ProductOrderMany = new List<ProductOrderMany>();
        }

    }
}
