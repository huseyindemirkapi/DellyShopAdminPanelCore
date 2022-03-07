using DellyShop.Data;
using DellyShop.Domain;
using DellyShop.Domain.Models;
using DellyShop.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DellyShop.Repos
{
    public class ImageRepository
    {
        private ApplicationDbContext _Db;
        private readonly DbSet<ImageModel> _ImageModel;
        public ImageRepository(ApplicationDbContext db)
        {
            _Db = db;
            _ImageModel = _Db.ImageModels;
        }

        public ImageModel Create(ImageModel model)
        {

            try
            {
                _ImageModel.Add(model);
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("The Image could not upload.Please try again");
            }

            return model;
        }
        public ImageModel GetImage(int imgID)
        {
            return _Db.ImageModels
                .Where(x => x.Id == imgID && x.IsActive == true && x.IsProductImage == true)
                .FirstOrDefault();
        }
        public ImageModel GetCategoryImage(int imgID)
        {
            return _Db.ImageModels
                .Where(x => x.Id == imgID && x.IsActive == true && x.IsProductImage == false)
                .FirstOrDefault();
        }
        public List<ImageModel> GetImagesByProductId(int productId)
        {
            return _Db.ImageModels
                .Include(y => y.Category)
                .Include(t => t.Product)
                .Where(x => x.Product.Id == productId && x.IsActive == true && x.IsProductImage == true).ToList();
        }
        public List<ImageModel> GetImagesByCategoryId(int categoryId)
        {
            return _Db.ImageModels
                .Include(y => y.Category)
                .Include(t => t.Product)
                .Where(x => x.Category.Id == categoryId && x.IsActive == true && x.IsProductImage == false).ToList();
        }

        public ApiResult GetImagesApiResult(List<ImageModel> images)
        {
            var list = new List<ProductImageCreateOrEditVM>();

            foreach (var image in images)
            {
                var viewModel = new ProductImageCreateOrEditVM()
                {
                    Id = image.Id,
                    ImageName = image.ImageName,
                    ImagePath = image.ImagePath,
                    ProductId = image.Product.Id,
                    IsProductImage = image.IsProductImage
                };
                list.Add(viewModel);
            }
            return new ApiResult
            {
                Entity = list,
                Message = "OK"
            };

        }
        public ApiResult Delete(int imgID)
        {

            var image = GetImage(imgID);

            image.IsActive = false;

            try
            {
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return new ApiResult
            {
                Message = "OK"
            };
        }
    }
}
