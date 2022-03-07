using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellyShop.Domain.Models;
using DellyShop.Domain.ViewModels;
using DellyShop.Repos;
using DellyShopCoreWebApp.Models;
using DellyShopCoreWebAppAdminPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace DellyShopCoreWebAppAdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        private RepositoryService _repo;
        public CategoryController(RepositoryService repo)
        {
            _repo = repo;
        }
        public IActionResult Index(CategoryIndexViewModel viewModel)
        {
            List<Category> categories = _repo.Categories.GetCategories(viewModel.SelectedCategory);
            viewModel.Categories = categories;

            return View(viewModel);
        }
        public IActionResult Create()
        {
            //var categories = _repo.Categories.GetCategoriesByProductId(viewModel.SelectedProduct);

            //viewModel.Categories = categories;
            CategoryCreateOrEditViewModel viewModel = new CategoryCreateOrEditViewModel()
            {
                Action = "Create",
                Button = "Create",
                Title = "Category Create",
                IsActive = true
            };

            return View("CreateOrEdit", viewModel);
        }
        [HttpPost]
        public IActionResult Create(CategoryCreateOrEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _repo.Categories.Create(viewModel);
                if (result == "OK")
                {
                    return View("Info", new InfoViewModel(viewModel.CategoryName + " The Category is Added."));
                }

                return View("Error", new ErrorViewModel("Could not add category , please try again."));
            }
            return View("Error", new ErrorViewModel("The values you submitted are not suitable, please try again."));
        }
        public IActionResult Edit(int id)
        {
            var category = _repo.Categories.GetCategoryById(id);
            CategoryCreateOrEditViewModel viewModel = new CategoryCreateOrEditViewModel()
            {
                Action = "Edit",
                Button = "Update",
                Title = "Catgory Update",
                CategoryName = category.CategoryName,
                Id = category.Id,
                IsActive = category.IsActive,
                Description = category.Description
            };

            return View("CreateOrEdit", viewModel);
        }
        [HttpPost]
        public IActionResult Edit(CategoryCreateOrEditViewModel viewModel)
        {
            var result = _repo.Categories.Update(viewModel);

            if (result == "OK")
            {
                return View("Info", new InfoViewModel(viewModel.CategoryName + " The Category is updated."));
            }

            return View("Error", new ErrorViewModel("Could not update category , please try again."));
        }

        public IActionResult Delete(int id)
        {
            Category category = _repo.Categories.GetCategoryById(id);
            var result = _repo.Categories.Delete(category);

            if (result == "OK")
            {
                return View("Info", new InfoViewModel(category.CategoryName + " The Category is deleted."));
            }

            return View("Error", new ErrorViewModel("Could not delete category , please try again."));

        }

        public IActionResult EditOrCreateImage(int id)
        {
            CategoryImageCreateOrEditVM viewModel = new CategoryImageCreateOrEditVM();
            var category = _repo.Categories.GetCategoryById(id);
            viewModel.CategoryId = id;
            viewModel.CategoryName = category.CategoryName;
            //viewModel.ImageFileOrder = 1;
            return View("EditOrCreateImage", viewModel);
        }
    }
}
