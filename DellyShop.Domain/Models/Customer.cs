using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DellyShop.Domain.Models
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [StringLength(25)]
        public string Surname { get; set; }

        [Required]
        [StringLength(70)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordConfirm { get; set; }

        public bool IsActive { get; set; }

        public DateTime BirthDay { get; set; }

        public List<Order> Orders { get; set; }

        public List<Address> Addresses { get; set; }

        public List<Stars> Stars { get; set; }
        public List<Comment> Comments { get; set; }

        public List<CreditCard> CreditCards { get; set; }

        public List<MyFavorite> Favorites { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
            Addresses = new List<Address>();
            Stars = new List<Stars>();
            Comments = new List<Comment>();
            CreditCards = new List<CreditCard>();
            Favorites = new List<MyFavorite>();
        }
    }
}
