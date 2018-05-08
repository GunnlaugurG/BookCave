using BookCave.Data;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData()
        {
            var db = new DataContext();
            var books = new List<Book>()
            {
            };
            db.AddRange(books);
            db.SaveChanges();
        }
    }
}