using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.Models
{
    public class LastView
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<Product> LastViewProducts { get; set; }

        public LastView()
        {
            LastViewProducts = new List<Product>();
        }

    }
}
