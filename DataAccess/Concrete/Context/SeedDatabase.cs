using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Concrete.Context
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new AppContextDB();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Product.Count() == 0)
                {
                    context.Product.AddRange(Products);
                }
            }
            context.SaveChanges();
        }

        private static Product[] Products =
        {
            new Product(){ Name="kalem",    Price=20,   Stock=11},
            new Product(){ Name="silgi",    Price=25,   Stock=11},
            new Product(){ Name="masa",     Price=30,   Stock=11},
            new Product(){ Name="bardak",   Price=45,   Stock=11},
            new Product(){ Name="sandalye", Price=78,   Stock=11},
            new Product(){ Name="laptop",   Price=2532, Stock=11},
            new Product(){ Name="defter",   Price=7,    Stock=11},
            new Product(){ Name="kitap",    Price=35,   Stock=11},
        };
    }
}
