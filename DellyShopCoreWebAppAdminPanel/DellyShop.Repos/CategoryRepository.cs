using DellyShop.Data;
using DellyShop.Domain.Models;
using DellyShop.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DellyShop.Repos
{
    public class CategoryRepository
    {
        private ApplicationDbContext _Db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _Db = db;
        }

        public List<Category> GetCategories(int categoryId)
        {
            var query = _Db.Categories
                .Include(x => x.Products)
                .Include(y => y.Images)
                .Where(t => t.IsActive == true)
                .AsQueryable();

            if (categoryId != 0)
            {
                query = query.Where(x => x.Id == categoryId);
            }

            var categories = query.OrderByDescending(x => x.CreatedOn).ToList();

            return categories;

        }
        public Category GetCategoryById(int Id)
        {
            return _Db.Categories
                .Include(x => x.Images)
                .Include(y => y.Products)
                .Where(x => x.Id == Id && x.IsActive == true)
                .FirstOrDefault();
        }

        public string Create(CategoryCreateOrEditViewModel viewModel)
        {
            Category category = new Category()
            {
                CategoryName = viewModel.CategoryName,
                Description = viewModel.Description,
                IsActive = viewModel.IsActive,
                CreatedOn = DateTime.UtcNow
            };

            try
            {
                _Db.Categories.Add(category);
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return "OK";

        }
        public string Update(CategoryCreateOrEditViewModel viewModel)
        {
            var category = GetCategoryById(viewModel.Id);

            category.CategoryName = viewModel.CategoryName;
            category.Description = viewModel.Description;
            category.IsActive = viewModel.IsActive;
            category.ModifiedOn = DateTime.UtcNow;

            try
            {
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return "OK";
        }

        public string Delete(Category model)
        {
            model.IsActive = false;

            try
            {
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return "OK";
        }
        public List<Category> GetCategoriesByProductId(int selectedProduct)
        {
            var query = _Db.Categories
                .Include(x => x.Products)
                .Where(y => y.IsActive == true)
                .AsQueryable();


            if (selectedProduct != 0)
            {
                query = query.Where(x => x.Products.FirstOrDefault().Id == selectedProduct);
            }

            return query.ToList();
        }
    }
}
