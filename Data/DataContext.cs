using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Data
{
    public class DataContext : DbContext {
        public List<Book> books { get; set; }
        public List<Author> authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder
                .UseSqlServer(
                        "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H07;Persist Security Info=False;User ID=VLN2_2018_H07_usr;Password=r3dGeese42;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
        }
    }
}