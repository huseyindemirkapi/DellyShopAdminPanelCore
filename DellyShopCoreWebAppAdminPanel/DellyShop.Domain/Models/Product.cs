using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DellyShop.Domain.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public bool IsActive { get; set; }

        //public Byte[] ProductImage { get; set; }

        //[Required(ErrorMessage = "Please choose profile image")]
        //public string ProductPicture { get; set; }

        public List<ImageModel> ProductImages { get; set; }

        public int Quantity { get; set; }

        public int StockCount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModifiedOn { get; set; }
        public int StarAverage { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Stars> Stars { get; set; }

        public List<ProductOrderMany> ProductOrderMany { get; set; }

        public Product()
        {
            Comments = new List<Comment>();

            Stars = new List<Stars>();

            ProductOrderMany = new List<ProductOrderMany>();

            ProductImages = new List<ImageModel>();
        }
    }
}
