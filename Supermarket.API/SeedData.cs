using Bogus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.API.Data;
using Supermarket.API.Misc;
using Supermarket.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.API
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var env = serviceProvider.GetRequiredService<IHostingEnvironment>();
                var context = scope.ServiceProvider.GetService<SupermarketDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetService<RoleManager<ApplicationRole>>();

                if (!env.IsTest())
                {
                    context.Database.Migrate();
                }

                SeedUsers(context, userManager);
                SeedRoles(context, roleManager);
                SeedCategories(context);
                SeedProducts(context);

            }
        }

        public static void SeedUsers(SupermarketDbContext context, UserManager<ApplicationUser> userManager)
        {
            string password = "P@55w0rd";
            var faker = new Faker();
            var email = faker.Person.Email;
            var email2 = faker.Person.Email;
            var email3 = faker.Person.Email;
            var email4 = faker.Person.Email;

            var users = new List<ApplicationUser>()
            {
                
                new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    FullName = faker.Person.FullName
                },
                new ApplicationUser
                {
                    UserName = email2,
                    Email = email2,
                    EmailConfirmed = true,
                    FullName = faker.Person.FullName
                },
                new ApplicationUser
                {
                    UserName = email3,
                    Email = email3,
                    EmailConfirmed = true,
                    FullName = faker.Person.FullName
                },
                new ApplicationUser
                {
                    UserName = email4,
                    Email = email4,
                    EmailConfirmed = true,
                    FullName = faker.Person.FullName
                }
            };

            users.ForEach(user => {
                var dbUser = context.Users.FirstOrDefault(u => u.Email == user.Email);
                if (dbUser == null)
                {
                    var result = userManager.CreateAsync(user, password).Result;
                    if (!result.Succeeded)
                    {
                        Console.WriteLine("User Save Error: " + result.Errors.First().Description);
                    }
                    else
                    {
                        Console.WriteLine($"User { user.UserName } created");
                    }
                    if (user.UserName.Contains("admin"))
                    {
                        result = userManager.AddToRoleAsync(user, ApplicationUser.Roles.Admin).Result;
                    }
                    else if (user.UserName.Contains("manager"))
                    {
                        result = userManager.AddToRoleAsync(user, ApplicationUser.Roles.Manager).Result;
                    }
                    else if (user.UserName.Contains("storeKeeper"))
                    {
                        result = userManager.AddToRoleAsync(user, ApplicationUser.Roles.StoreKeeper).Result;
                    }
                    if (!result.Succeeded)
                    {
                        Console.WriteLine("User to Role Error: " + result.Errors.First().Description);
                    }
                }
            });
        }

        public static void SeedCategories(SupermarketDbContext context)
        {
            var categories = new List<Category>()
            {
                
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Electronics"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Toiletries"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Miscellaneous"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Fashion"
                }
            };

            categories.ForEach(category => {
                var dbCategory = context.Categories.FirstOrDefault(r => r.Name == category.Name);
                if (dbCategory == null)
                {
                    context.Categories.Add(category);
                }
            });

            context.SaveChanges();
        }

        public static void SeedProducts(SupermarketDbContext context)
        {
            var faker = new Faker();
            string product1 = faker.Commerce.ProductName();
            string product2 = faker.Commerce.ProductName();
            string product3 = faker.Commerce.ProductName();
            string product4 = faker.Commerce.ProductName();

            var category = context.Categories.FirstOrDefault(p => p.Name == "Electronics");
            var category2 = context.Categories.FirstOrDefault(p => p.Name == "Toiletries");
            var category3 = context.Categories.FirstOrDefault(p => p.Name == "Miscellaneous");
            var category4 = context.Categories.FirstOrDefault(p => p.Name == "Fashion");

            var products = new List<Product>()
            {
                new Product()
                {
                    Name = product1,
                    QuantityInStock = faker.Random.Number(1, 9),
                    UnitOfMeasurement = EUnitOfMeasurement.Kilogram,
                    CategoryId = category.Id
                },
                new Product()
                {
                    Name = product2,
                    QuantityInStock = faker.Random.Number(2, 12),
                    UnitOfMeasurement = EUnitOfMeasurement.Kilogram,
                    CategoryId = category2.Id
                },
                new Product()
                {
                    Name = product3,
                    QuantityInStock = faker.Random.Number(3, 13),
                    UnitOfMeasurement = EUnitOfMeasurement.Gram,
                    CategoryId = category3.Id
                },
                new Product()
                {
                    Name = product4,
                    QuantityInStock = faker.Random.Number(5, 15),
                    UnitOfMeasurement = EUnitOfMeasurement.Kilogram,
                    CategoryId = category4.Id
                }
            };

            products.ForEach(product =>
            {
                var dbProduct = context.Products.FirstOrDefault(p => p.Name == product.Name);
                if(dbProduct == null)
                {
                    context.Products.Add(product);
                }
            });

            context.SaveChanges();
        }

        public static void SeedRoles(SupermarketDbContext context, RoleManager<ApplicationRole> roleManager)
        {
            var roles = new List<ApplicationRole>()
            {
                new ApplicationRole()
                {
                    Name = ApplicationUser.Roles.admin,
                    NormalizedName = ApplicationUser.Roles.Admin
                },
                new ApplicationRole()
                {
                    Name = ApplicationUser.Roles.storeKeeper,
                    NormalizedName = ApplicationUser.Roles.StoreKeeper
                },
                new ApplicationRole()
                {
                    Name = ApplicationUser.Roles.manager,
                    NormalizedName = ApplicationUser.Roles.Manager
                },
            };

            roles.ForEach(role => {
                var dbRole = context.Roles.FirstOrDefault(r => r.Name == role.Name);

                if (dbRole == null)
                {
                    context.Roles.Add(role);
                }
            });

            context.SaveChanges();
        }
    }
}
