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
    public class UserRepository
    {
        private ApplicationDbContext _Db;
        private readonly DbSet<ApplicationUser> _Users;

        public UserRepository(ApplicationDbContext db)
        {
            _Db = db;
            _Users = _Db.Users;
        }
        public List<ApplicationUser> GetAllUsers(string selectedUser)
        {
            var query = _Users
                .Where(x => x.LockoutEnabled == true)
                .AsQueryable();

            if (selectedUser != null && selectedUser != "")
            {
                query = query.Where(x => x.Id == selectedUser);
            }

            query = query.OrderByDescending(x => x.CreatedAt);

            var users = query.ToList();

            return users;
        }
        //public string Create(UserCreateOrEditViewModel viewModel)
        //{
        //    var user = new ApplicationUser
        //    {
        //        FirstName = viewModel.FirstName,
        //        LastName = viewModel.LastName,
        //        Email = viewModel.Email,
        //        PhoneNumber = viewModel.PhoneNumber,
        //        CreatedAt = DateTime.UtcNow,
        //        //CreatedBy = User.Identity.Name,
        //        PasswordHash = viewModel.Password,
        //        LockoutEnabled = viewModel.LockoutEnabled
        //    };

        //    try
        //    {
        //        _Users.Add(user);
        //        _Db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex.InnerException;
        //    }

        //    return "OK";
        //}

        public string Update(UserCreateOrEditViewModel viewModel)
        {
            var findUser = GetAllUsers(viewModel.UserId);

            foreach (var user in findUser)
            {
                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;
                user.Email = viewModel.Email;
                user.PhoneNumber = viewModel.PhoneNumber;
                user.PasswordHash = viewModel.Password;
                user.LockoutEnabled = viewModel.LockoutEnabled;
            }

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
        public string Delete(ApplicationUser user)
        {
            
            user.LockoutEnabled = false;

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
