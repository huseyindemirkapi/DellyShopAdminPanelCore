using DellyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DellyShop.Domain.ViewModels
{
    public class UserViewModel
    {
        public string SelectedUser { get; set; }

        //public List<UserBaseViewModel> Users { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}
