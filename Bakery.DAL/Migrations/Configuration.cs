using Bakery.DAL.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Web.Helpers;

namespace Bakery.DAL.Migrations
{
    public class Configuration : DbMigrationsConfiguration<BakeryContext>
    {
       protected override void Seed(BakeryContext db)
        {
            // GetCategories().ForEach(c => db.Category.Add(c));
            //GetProducts().ForEach(c => db.Product.Add(c));

            //db.Role.Add(new Role { Name="Admin"});
            //db.Role.Add(new Role { Name = "User" });

            db.User.Add(new User { Email="admin@gmail.com", Password=Crypto.HashPassword("123456"), RoleId=1});
            base.Seed(db);
        }


        private static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Name="Cake"},
                new Category { Name="Cookie"},
                new Category { Name="Pastry"},
                new Category { Name="Bread"}

            };
        }

        private static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Name ="Cookie with chocolate", Price=2.15m, Url="Cookies/1.JPG", CatId=2},
                new Product { Name ="Kuchukay", Price=3.17m, Url="Cookies/2.JPG", CatId=2},
                new Product { Name ="Cheese biscuits", Price=2.84m, Url="Cookies/3.JPG", CatId=2},
                new Product { Name ="Brushwood", Price=4.22m, Url="Cookies/4.JPG", CatId=2},
                new Product { Name ="Viennese cookie", Price=3.45m, Url="Cookies/5.JPG", CatId=2},
                new Product { Name ="Makaron", Price=4, Url="Cookies/6.JPG", CatId=2},
                new Product { Name ="Moo-moo", Price=2.77m, Url="Cookies/7.JPG", CatId=2},
                new Product { Name ="Rosette", Price=3.95m, Url="Cookies/8.JPG", CatId=2},
                new Product { Name ="Oat cookies", Price=2.15m, Url="Cookies/9.JPG", CatId=2},
                new Product { Name ="Shortcake", Price=1.80m, Url="Cookies/10.JPG", CatId=2},
                new Product { Name ="Shortcake", Price=1.95m, Url="Cookies/11.JPG", CatId=2},
                new Product { Name ="Waffle", Price=3.60m, Url="Cookies/12.JPG", CatId=2},
                new Product { Name ="Nutlet", Price=3.85m, Url="Cookies/13.JPG", CatId=2},

                 new Product { Name ="Cherry pie", Price=35, Url="Pastry/1.JPG", CatId=3},
                 new Product { Name ="Potpie", Price=42, Url="Pastry/2.JPG", CatId=3},
                 new Product { Name ="Smetannik with berries", Price=54, Url="Pastry/3.JPG", CatId=3},
                 new Product { Name ="Cheese pie", Price=28, Url="Pastry/4.JPG", CatId=3},
                 new Product { Name ="Spinach pie", Price=36, Url="Pastry/5.JPG", CatId=3},
                 new Product { Name ="Pie with cabbage", Price=29, Url="Pastry/6.JPG", CatId=3},


                 new Product { Name ="Irish bread", Price=23, Url="Bread/1.JPG", CatId=4},
                 new Product { Name ="Pumpkin bread", Price=14, Url="Bread/2.JPG", CatId=4},
                 new Product { Name ="Rye bread", Price=17, Url="Bread/3.JPG", CatId=4},
                 new Product { Name ="Corn bread", Price=19, Url="Bread/4.JPG", CatId=4},
                 new Product { Name ="Focaccia bread", Price=25, Url="Bread/5.JPG", CatId=4}

            };
        }

       
        


    }

}

