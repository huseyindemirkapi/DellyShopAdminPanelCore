using DellyShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.Models
{
    public class Order
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

        //[ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public List<ProductOrderMany> ProductOrderMany { get; set; }

        public Order()
        {
            ProductOrderMany = new List<ProductOrderMany>();
        }
    }
}
