using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.Models
{
    public class MyFavorite
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public bool IsActive { get; set; }

        public List<Product> Products { get; set; }

        public MyFavorite()
        {
            Products = new List<Product>();
        }

    }
}
