using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BookCave.Data;
using BookCave.Data.EntityModels;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData() {

            var db = new DataContext();
            if(!db.books.Any()) {
            var initialBooks = new List<Book>() {
                new Book{ title = "Lord Of The rings: The fellowship of the ring", genre="Adventure", cost=10.99}
            };
            db.AddRange();
            db.SaveChanges();
            //hehe
            }
        }
    }
    
}
