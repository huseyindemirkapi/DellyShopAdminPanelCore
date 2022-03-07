using DellyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DellyShop.Domain.ViewModels
{
    public class ProductIndexViewModel
    {
        public int ProductId { get; set; }

        public int SelectedCategory { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Stars> Stars { get; set; }

        public List<Category> Categories { get; set; }

        public List<Product> Products { get; set; }

        public ProductIndexViewModel()
        {
            Comments = new List<Comment>();

            Stars = new List<Stars>();

            Categories = new List<Category>();

            Products = new List<Product>();
        }

    }
}
