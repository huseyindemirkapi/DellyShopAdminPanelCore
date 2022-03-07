using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DellyShop.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

using System.Threading;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using DellyShop.Repos;
using DellyShop.Domain.Models;

namespace DellyShopCoreWebAppAdminPanel.Controllers
{
    public class ImageController : Controller
    {
        private IHostingEnvironment _env;
        private RepositoryService _repo;

        public ImageController(IHostingEnvironment env, RepositoryService repo)
        {
            _env = env;
            _repo = repo;
        }
        //public JsonResult ImageUpload(ProductImageCreateOrEditVM model)
        //{

        //    var file = model.ImageFile;
        //    var filePath = Path.GetTempFileName();

        //    if (file != null)
        //    {
        //        var extention = Path.GetExtension(file.FileName);
        //        var fileName = model.Id.ToString() + "_" + model.ImageFileOrder + extention;// Path.GetFileName(file.FileName);
        //        var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

        //        //  filePath = "C:\\Users\\Corco\\Desktop\\DellyAdmin\\DellyShopCoreWebAppAdminPanel\\DellyShopCoreWebApp\\wwwroot\\UploadImages\\";

        //        filePath = Path.Combine(_env.WebRootPath, "UploadImages", fileName);

        //        using (var stream = System.IO.File.Create(filePath))
        //        {
        //            file.CopyTo(stream);
        //        }
        //        string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
        //        //Server.MapPath("/UploadedImage/" + file.FileName)
        //        return Json(baseUrl + "/UploadImages/" + fileName);
        //    }

        //    return Json("UploadImages/");
        //    // return View("Info", new InfoViewModel(model.ProductName + " image is added"));

        //}
        public IActionResult ImageUpload(ProductImageCreateOrEditVM model)
        {
            var product = _repo.Products.GetProductDetail(model.ProductId);
            var file = model.ImageFile;
            var filePath = Path.GetTempFileName();
            byte[] imageByte = null;
            int imgId = 0;

            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var fileName = file.FileName; //model.Id.ToString() + "_" + model.ImageFileOrder + extention;// Path.GetFileName(file.FileName);
                var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);
                string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

                BinaryReader reader = new BinaryReader(file.OpenReadStream());

                imageByte = reader.ReadBytes(Convert.ToInt32(file.Length));

                ImageModel imageModel = new ImageModel()
                {
                    ImageName = fileName,
                    Images = imageByte,
                    ImagePath = /*baseUrl + */"/UploadImages/" + fileName,
                    IsActive = true,
                    Product = product,
                    CategoryId = product.CategoryId,
                    IsProductImage = true
                };

                _repo.Images.Create(imageModel);

                imgId = imageModel.Id;

                //filePath = Path.Combine(baseUrl + "/UploadImages/" + fileName + "_" + imgId);

                filePath = Path.Combine(_env.WebRootPath, "UploadImages", filenamewithoutextension + "_" + imgId + extention);

                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }

                //Server.MapPath("/UploadedImage/" + file.FileName)
                return Json(imgId);
            }

            return Json(0);
        }
        public IActionResult ImageRetrieve(int imgID)
        {
            var result = _repo.Images.GetImage(imgID);

            return File(result.Images, "image/jpg");
        }

        public IActionResult GetProductImage(int productId)
        {

            var imageList = _repo.Images.GetImagesByProductId(productId);

            var images = _repo.Images.GetImagesApiResult(imageList);

            return Ok(images);
        }
        
        /// <summary>
        /// Different additions for categories
        /// </summary>
        /// <param ></param>
        public IActionResult CategoryImageUpload(CategoryImageCreateOrEditVM model)
        {
            var category = _repo.Categories.GetCategoryById(model.CategoryId);
            var file = model.ImageFile;
            var filePath = Path.GetTempFileName();
            byte[] imageByte = null;
            int imgId = 0;

            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var fileName = file.FileName; //model.Id.ToString() + "_" + model.ImageFileOrder + extention;// Path.GetFileName(file.FileName);
                var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);
                string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

                BinaryReader reader = new BinaryReader(file.OpenReadStream());

                imageByte = reader.ReadBytes(Convert.ToInt32(file.Length));

                ImageModel imageModel = new ImageModel()
                {
                    ImageName = fileName,
                    Images = imageByte,
                    ImagePath = /*baseUrl + */"/CategoryUploadImages/" + fileName,
                    IsActive = true,
                    Category = category,
                    Product = category.Products.FirstOrDefault(),
                    IsProductImage = false
                };

                _repo.Images.Create(imageModel);

                imgId = imageModel.Id;

                //filePath = Path.Combine(baseUrl + "/UploadImages/" + fileName + "_" + imgId);

                filePath = Path.Combine(_env.WebRootPath, "UploadImages", filenamewithoutextension + "_" + imgId + extention);

                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }

                //Server.MapPath("/UploadedImage/" + file.FileName)
                return Json(imgId);
            }

            return Json(0);
        }
        public IActionResult CategoryImageRetrieve(int imgID)
        {
            var result = _repo.Images.GetCategoryImage(imgID);

            return File(result.Images, "image/jpg");
        }

        public IActionResult GetCategoryImage(int categoryId)
        {
            var imageList = _repo.Images.GetImagesByCategoryId(categoryId);

            var images = _repo.Images.GetImagesApiResult(imageList);

            return Ok(images);
        }

        /// <summary>
        ///             Common
        /// </summary>
        public IActionResult DeleteImage(int imgID)
        {
            var result = _repo.Images.Delete(imgID);

            return Ok(result);
        }
    }
}
