using DellyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DellyShop.Domain.ViewModels
{
    public class CategoryCreateOrEditViewModel
    {
        public string Action { get; set; }
        public string Title { get; set; }
        public string Button { get; set; }

        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; }

        public Byte[] CategoryBGImage { get; set; }

        public List<ImageModel> Images { get; set; }

        public CategoryCreateOrEditViewModel()
        {
            Images = new List<ImageModel>();
        }


    }
}
