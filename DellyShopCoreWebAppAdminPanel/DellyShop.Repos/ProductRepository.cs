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
    public class ProductRepository
    {
        private ApplicationDbContext _Db;
        private readonly DbSet<Product> _Product;
        public ProductRepository(ApplicationDbContext db)
        {
            _Db = db;
            _Product = _Db.Products;
        }
        public Product Create(Product model)
        {

            try
            {
                _Product.Add(model);
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("The product could not be registered.Please try again." + ex.InnerException);
            }

            return model;
        }
        public string Update(ProductCreateOrEditViewModel viewModel)
        {
            Product model = GetProductDetail(viewModel.Id);

            model.CategoryId = viewModel.SelectedCategory;
            model.Currency = viewModel.Currency;
            model.Description = viewModel.Description;
            model.IsActive = viewModel.IsActive;
            model.ModifiedOn = DateTime.UtcNow;
            model.Name = viewModel.Name;
            model.Price = viewModel.Price;
            model.StockCount = viewModel.StockCount;

            try
            {
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("The product could not be updated.Please try again." + ex.InnerException);
            }

            return "OK";

        }
        public Product GetProductDetail(int productId)
        {
            //TODO
            //ufuk benden her product detail istediğinde ben de onu lastView a eklenecek.
            var query = _Db.Products
                .Include(y => y.Category)
                .Where(x => x.Id == productId && x.IsActive == true)
                .FirstOrDefault();

            return query;
        }
        public List<Product> GetProducts(int categoryId)
        {
            var query = _Db.Products
                .Include(x => x.Category)
                .Include(y => y.ProductImages)
                .Where(t => t.IsActive == true)
                .AsQueryable();

            if (categoryId != 0)
            {
                query = query.Where(t => t.CategoryId == categoryId);
            }

            var products = query
                                .OrderByDescending(x => x.CreatedOn)
                                .ToList();

            return products;
        }
        public string Delete(Product model)
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
    }
}
