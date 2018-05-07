using BookCave.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookCave.Data
{
    public class DataContext : DbContext {
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<UserAccount> userAccounts { get; set; }
        public DbSet<Review> Reviews { get; set; }  
        public DbSet<ShippingInfo> shipingInfo {get; set;}
        public DbSet<CardInfo> cardInfo {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder
                .UseSqlServer(
                        "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H07;Persist Security Info=False;User ID=VLN2_2018_H07_usr;Password=r3dGeese42;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
        }
    }
}