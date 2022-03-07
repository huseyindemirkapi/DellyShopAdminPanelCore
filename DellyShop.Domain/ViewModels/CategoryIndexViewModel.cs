using DellyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.ViewModels
{
    public class CategoryIndexViewModel
    {
        public int SelectedCategory { get; set; }

        public List<Category> Categories { get; set; }
    }
}
