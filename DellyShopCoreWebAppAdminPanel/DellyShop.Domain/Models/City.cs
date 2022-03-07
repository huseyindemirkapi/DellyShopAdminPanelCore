using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.Models
{
    public class City
    {
        public int Id { get; set; }

        public int PlateCode { get; set; }

        public bool IsActive { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public List<District> Districts { get; set; }

        public List<Address> Addresses { get; set; }

        public string NormalizedName { get; set; }

        public City()
        {
            Districts = new List<District>();
            Addresses = new List<Address>();
        }
    }
}
