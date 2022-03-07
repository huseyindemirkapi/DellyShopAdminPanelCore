using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DellyShop.Domain.Models;
using DellyShop.Domain.ViewModels;
using DellyShop.Repos;
using DellyShopCoreWebApp.Models;
using DellyShopCoreWebAppAdminPanel.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DellyShopCoreWebAppAdminPanel.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private RepositoryService _repo;
        private readonly List<Comment> comments;
        private readonly List<Category> categories;


        public ProductController(ILogger<ProductController> logger, RepositoryService repo, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _repo = repo;
            comments = _repo.Comments.GetCommentsByProductId(0);
            categories = _repo.Categories.GetCategories(0);
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index(ProductIndexViewModel viewModel)
        {
            var products = _repo.Products.GetProducts(viewModel.SelectedCategory);

            viewModel.Comments = comments;
            viewModel.Categories = categories;
            viewModel.Products = products;

            return View(viewModel);
        }

        public IActionResult Create()
        {
            ProductCreateOrEditViewModel viewModel = new ProductCreateOrEditViewModel()
            {
                Categories = categories,
                Action = "/Product/Create",
                Button = "Create",
                Title = "Product Create",
                IsActive = true
            };

            return View("CreateOrEdit", viewModel);
        }

        public IActionResult Edit(int id)
        {
            Product product = _repo.Products.GetProductDetail(id);
            List<Category> productCategory = categories;
            ProductCreateOrEditViewModel viewModel = new ProductCreateOrEditViewModel()
            {
                SelectedCategory = product.CategoryId,
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockCount = product.StockCount,
                IsActive = product.IsActive,
                Categories = productCategory,
                Action = "/Product/Edit",
                Button = "Edit",
                Title = "Product Edit"
            };

            return View("CreateOrEdit", viewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateOrEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    CategoryId = viewModel.SelectedCategory,
                    Name = viewModel.Name,
                    IsActive = viewModel.IsActive,
                    StockCount = viewModel.StockCount,
                    Description = viewModel.Description,
                    Price = viewModel.Price,
                    CreatedOn = DateTime.UtcNow
                };

                _repo.Products.Create(product);

                return RedirectToAction("Index");
            }

            return View("Error", new ErrorViewModel("The values you submitted are not suitable, please try again."));
        }

        [HttpPost]
        public IActionResult Edit(ProductCreateOrEditViewModel viewModel)
        {
            var result = _repo.Products.Update(viewModel);
            if (result == "OK")
            {
                return View("Info", new InfoViewModel(viewModel.Name + " The Product is Updated."));
            }

            return View("Error", new ErrorViewModel("Could not add product , please try again."));

        }
        public IActionResult Delete(int id)
        {
            Product product = _repo.Products.GetProductDetail(id);

            var result = _repo.Products.Delete(product);

            if (result == "OK")
            {
                return View("Info", new InfoViewModel(product.Name + " The Product is deleted."));
            }

            return View("Error", new ErrorViewModel("Could not delete product , please try again."));

        }
        public IActionResult EditOrCreateImage(int id)
        {
            ProductImageCreateOrEditVM viewModel = new ProductImageCreateOrEditVM();
            Product product = _repo.Products.GetProductDetail(id);

            viewModel.ProductId = id;
            viewModel.ProductName = product.Name;
            //viewModel.ImageFileOrder = 1;
            return View("EditOrCreateImage", viewModel);
        }
        //public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        //{
        //    long size = files.Sum(f => f.Length);

        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            var filePath = Path.GetTempFileName();

        //            using (var stream = System.IO.File.Create(filePath))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }

        //    // Process uploaded files
        //    // Don't rely on or trust the FileName property without validation.

        //    return Ok(new { count = files.Count, size });
        //}
        //public IActionResult ImageUpload(ProductImageCreateOrEditVM model)
        //{

        //    var file = model.ImageFile;

        //    if (file != null)
        //    {

        //        var fileName = Path.GetFileName(file.FileName);
        //        var extention = Path.GetExtension(file.FileName);
        //        var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);
        //        var filePath = Path.GetTempFileName();

        //        using (var stream = System.IO.File.Create(filePath))
        //        {
        //            file.CopyToAsync(stream);
        //        }


        //        //Server.MapPath("/UploadedImage/" + file.FileName)
        //    }

        //    return Json(file.FileName, JsonRequestBehavior.AllowGet);
        //   // return View("Info", new InfoViewModel(model.ProductName + " image is added"));

        //}

        //private string UploadedFile(ProductCreateOrEditViewModel model)
        //{
        //    string uniqueFileName = null;

        //    if (model.ImageFile != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.ImageFile.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}

        //[HttpPost]
        //public async Task<IActionResult> UploadPictures(ProductCreateOrEditViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var product = new Product
        //        {
        //            CategoryId = viewModel.SelectedCategory,
        //            Name = viewModel.Name,
        //            IsActive = viewModel.IsActive,
        //            StockCount = viewModel.StockCount,
        //            Description = viewModel.Description,
        //            Price = viewModel.Price,
        //            CreatedOn = DateTime.UtcNow
        //        };

        //        byte[] fileBytes;
        //        using (var ms = new MemoryStream())
        //        {
        //            viewModel.ImageFile.CopyTo(ms);
        //            fileBytes = ms.ToArray();

        //            // act on the Base64 data
        //        }
        //        product.ProductImages.Add(new ImageModel()
        //        {
        //            Images = fileBytes,
        //            CategoryId = viewModel.SelectedCategory
        //        });

        //        _repo.Products.Create(product);


        //        return View("Info", new InfoViewModel(viewModel.Name + " is added"));

        //    }

        //    return View("Error", new ErrorViewModel("The values you submitted are not suitable, please try again."));
        //}


    }
    //public JsonResult ImageUpload(ProductCreateOrEditViewModel viewModel)
    //{
    //    var file = viewModel.ImageFile;
    //    byte[] imagebyte = null;


    //    if (file != null)
    //    {
    //        //BinaryReader reader = new BinaryReader(file.InputStream);
    //        var fileName = Path.GetFileName(file.FileName);
    //        var extention = Path.GetExtension(file.FileName);
    //        var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

    //        //file.SaveAs(Server.MapPath("/UploadedImage/" + file.FileName));


    //    }

    //    return Json(file.FileName, JsonRequestBehavior.AllowGet);
    //}
    //public ActionResult ImageRetrieve(int imgID)
    //{
    //    MVCTutorialEntities db = new MVCTutorialEntities();

    //    var img = db.ImageStores.SingleOrDefault(x => x.ImageId == imgID);

    //    return File(img.ImageByte, "image/jpg");


    //}


}
