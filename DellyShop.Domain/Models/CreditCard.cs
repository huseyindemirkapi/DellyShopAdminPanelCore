using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

    }
}
