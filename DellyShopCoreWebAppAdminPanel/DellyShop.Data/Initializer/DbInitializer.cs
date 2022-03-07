using DellyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Data.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            DataInitializer.Initialize(context);
        }
    }
}
