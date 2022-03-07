using DellyShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DellyShop.Domain.ViewModels
{
    public class ProductCreateOrEditViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please Enter Price")]
        [Range(0.00001, 99999999999, ErrorMessage = "Please enter a number greater than 0..")]
        public decimal Price { get; set; }

        public string Currency { get; set; }

        public bool IsActive { get; set; }

        public IFormFile ImageFile { get; set; }

        public int StockCount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModifiedOn { get; set; }
        public int StarAverage { get; set; }

        public int SelectedCategory { get; set; }

        public List<Category> Categories { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Stars> Stars { get; set; }

        public List<ProductOrderMany> ProductOrderMany { get; set; }

        public List<ImageModel> ProductImages { get; set; }

        public ProductCreateOrEditViewModel()
        {
            Comments = new List<Comment>();

            Stars = new List<Stars>();

            ProductOrderMany = new List<ProductOrderMany>();

            Categories = new List<Category>();

            ProductImages = new List<ImageModel>();
        }


        public string Action { get; set; }
        public string Title { get; set; }
        public string Button { get; set; }
    }
}
