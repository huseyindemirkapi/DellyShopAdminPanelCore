using DellyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.ViewModels
{
    public class CommentIndexViewModel
    {
        public List<Comment> Comments { get; set; }

        public int SelectedProduct { get; set; }
        public List<Product> Products { get; set; }

    }
}
