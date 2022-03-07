using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellyShop.Domain.ViewModels;
using DellyShop.Repos;
using DellyShopCoreWebApp.Models;
using DellyShopCoreWebAppAdminPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace DellyShopCoreWebAppAdminPanel.Controllers
{
    public class CommentController : Controller
    {
        private RepositoryService _repo;
        public CommentController(RepositoryService repo)
        {
            _repo = repo;
        }
        public IActionResult Index(CommentIndexViewModel viewModel)
        {
            var product = _repo.Products.GetProducts(0);
            var comment = _repo.Comments.GetCommentsByProductId(viewModel.SelectedProduct);
            viewModel.Comments = comment;
            viewModel.Products = product;

            return View(viewModel);
        }
        public IActionResult Delete(int id)
        {
            var result = _repo.Comments.Delete(id);

            if (result == "OK")
            {
                return View("Info", new InfoViewModel("Comment is deleted id = " + id));
            }

            return View("Error", new ErrorViewModel("Could not delete comment , please try again."));
        }
    }
}
