using DellyShop.Domain.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Data.Initializer
{
    public class DataInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Customers.Any())
            {
                //adding Category
                for (int i = 0; i < 10; i++)
                {
                    Category category = new Category()
                    {
                        CategoryName = FakeData.PlaceData.GetStreetName(),
                        Description = FakeData.TextData.GetSentence(),
                        CreatedOn = FakeData.DateTimeData.GetDatetime(),
                        IsActive = FakeData.BooleanData.GetBoolean(),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime()
                    };

                    context.Categories.Add(category);




                    //Adding Product
                    for (int k = 0; k < FakeData.NumberData.GetNumber(5, 9); k++)
                    {
                        Product product = new Product();

                        product.Name = FakeData.PlaceData.GetCity();
                        product.Category = category;
                        product.StarAverage = FakeData.NumberData.GetNumber(3, 5);
                        product.CreatedOn = FakeData.DateTimeData.GetDatetime();
                        product.ModifiedOn = FakeData.DateTimeData.GetDatetime();
                        product.Price = Convert.ToDecimal(FakeData.NumberData.GetDouble());
                        product.StockCount = FakeData.NumberData.GetNumber(3, 25);
                        product.Description = FakeData.TextData.GetSentence();
                        //product.ProductOrderMany = 

                        category.Products.Add(product);

                        //Adding Comment
                        for (int h = 0; h < FakeData.NumberData.GetNumber(2, 5); h++)
                        {
                            Comment comment = new Comment()
                            {
                                Product = product,
                                Text = FakeData.TextData.GetSentence(),
                                CreatedOn = FakeData.DateTimeData.GetDatetime(),
                                ModifiedOn = FakeData.DateTimeData.GetDatetime()

                            };

                            product.Comments.Add(comment);
                        }

                        //adding liked


                        //for (int m = 0; m < product.; m++)
                        //{
                        //    Stars liked = new Stars()
                        //    {
                        //        LikedUser = users[m]
                        //    };
                        //    product.Likeds.Add(liked);
                        //}
                    }

                }


                Customer customer1 = new Customer()
                {
                    Name = "ufuk",
                    Surname = "zimmer",
                    Email = "admin@gmail.com",
                    Password = "123456",
                    PhoneNumber = "55555",
                    IsActive = true,
                    PasswordConfirm = "123456"
                };

                Customer customer2 = new Customer()
                {
                    Name = "husi",
                    Surname = "corco",
                    Email = "corco@gmail.com",
                    Password = "123456",
                    PhoneNumber = "666666",
                    IsActive = true,
                    PasswordConfirm = "123456"
                };

                context.Customers.Add(customer1);
                context.Customers.Add(customer2);


                for (int i = 0; i < 10; i++)
                {
                    Customer customer = new Customer()
                    {
                        Name = FakeData.NameData.GetFirstName(),
                        Surname = FakeData.NameData.GetSurname(),
                        Email = FakeData.NetworkData.GetEmail(),
                        Password = "123456",
                        PhoneNumber = FakeData.PhoneNumberData.GetPhoneNumber(),
                        IsActive = true,
                        PasswordConfirm = "123456"

                    };
                    context.Customers.Add(customer);

                    var numberstate = FakeData.NumberData.GetNumber(1, 3);

                    Order order = new Order()
                    {
                        Description = FakeData.TextData.GetSentence(),
                        CreatedOn = FakeData.DateTimeData.GetDatetime(),
                        Customer = customer,
                        OrderState = (Domain.Enums.OrderState)numberstate,
                        ShippingCostPrice = Convert.ToDecimal(FakeData.NumberData.GetNumber(8, 15)),
                        TotalPrice = Convert.ToDecimal(FakeData.NumberData.GetNumber(50, 250)),
                        OrderCount = FakeData.NumberData.GetNumber(1, 3),
                        //ProductOrderMany = 
                    };

                    context.Orders.Add(order);

                }

                context.SaveChanges();
            }

        }
    }
}
