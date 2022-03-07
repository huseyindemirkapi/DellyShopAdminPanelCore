using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.Models
{
    public class District
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public List<Address> Addresses { get; set; }

        public string NormalizedName { get; set; }
    }
}
