using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Repos
{
    public class DependenciesForRepositories
    {

        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<CategoryRepository, CategoryRepository>();
            services.AddScoped<ProductRepository, ProductRepository>();
            services.AddScoped<CommentRepository, CommentRepository>();
            services.AddScoped<UserRepository, UserRepository>();
            services.AddScoped<OrderRepository, OrderRepository>();
            services.AddScoped<CustomerRepository, CustomerRepository>();
            services.AddScoped<ImageRepository, ImageRepository>();
        }
    }
}
