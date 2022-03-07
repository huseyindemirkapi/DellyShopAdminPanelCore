using DellyShop.Data;
using DellyShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DellyShop.Repos
{
    public class CommentRepository
    {
        private ApplicationDbContext _Db;
        public CommentRepository(ApplicationDbContext db)
        {
            _Db = db;
        }
        public Comment GetComment(int id)
        {
            return _Db.Comments.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Comment> GetCommentsByProductId(int productId)
        {

            var query = _Db.Comments.Include(x => x.Product)
                .AsQueryable();

            if (productId != 0)
            {
                query = query.Where(x => x.ProductId == productId).OrderByDescending(y => y.CreatedOn);
            }

            var comments = query.ToList();

            return comments;
        }
        public string Delete(int id)
        {
            var comment = GetComment(id);
            comment.IsActive = false;

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
