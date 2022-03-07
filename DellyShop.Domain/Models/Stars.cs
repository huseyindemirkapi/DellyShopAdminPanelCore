using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.Models
{
    public class Stars
    {
        public int Id { get; set; }

        public int StarCount { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
