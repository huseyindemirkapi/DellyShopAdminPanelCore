using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.ViewModels
{
    public class ProductImageCreateOrEditVM
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public string ImageName { get; set; }

        public Byte[] Images { get; set; }

        public bool IsActive { get; set; }
        public IFormFile ImageFile { get; set; }
        public int ImageFileOrder { get; set; }

        public int ProductId { get; set; }

        public bool IsProductImage { get; set; }

        public string ProductName { get; set; }

    }
}
