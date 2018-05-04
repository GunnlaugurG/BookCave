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
            var authors = new List<Author>() {
             new Author {
                    authorName = "Salman Rushdie",
                    image = "http://www.notablebiographies.com/images/uewb_09_img0619.jpg"
                },
             new Author {
                    authorName = "F. Scott Fitzgerald",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/F_Scott_Fitzgerald_1921.jpg/440px-F_Scott_Fitzgerald_1921.jpg"
                }
            };
            db.AddRange(authors);
            db.SaveChanges();
        }
    }
}
