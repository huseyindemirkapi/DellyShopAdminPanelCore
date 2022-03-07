using DellyShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //[Display(Name = "Adres Tipi :")]
        public AddressType AddressType { get; set; }

        //[Display(Name = "Şehir :")]
        public City City { get; set; }
        //[Display(Name = "İlçe :")]
        public District District { get; set; }
        //[Display(Name = "Ülke :")]
        public Country Country { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
