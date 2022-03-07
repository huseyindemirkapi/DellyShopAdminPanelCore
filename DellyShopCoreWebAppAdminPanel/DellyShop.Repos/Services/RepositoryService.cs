using DellyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Repos
{
    public class RepositoryService
    {
        public CategoryRepository Categories { get; set; }
        public ProductRepository Products { get; set; }
        public CommentRepository Comments { get; set; }

        public UserRepository Users { get; set; }

        public OrderRepository Orders { get; set; }

        public CustomerRepository Customers { get; set; }
        public ImageRepository Images { get; set; }

        public RepositoryService(CategoryRepository _Categories,
            ProductRepository _Products,
            CommentRepository _Comment,
            UserRepository _User,
            OrderRepository _Order,
            CustomerRepository _Customer,
            ImageRepository _Images)
        {
            Categories = _Categories;
            Products = _Products;
            Comments = _Comment;
            Users = _User;
            Orders = _Order;
            Customers = _Customer;
            Images = _Images;
        }
    }
}
