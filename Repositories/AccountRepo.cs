using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;

namespace BookCave.Repositories
{
    public class AccountRepo
    {
        public void addUserToDataBase(UserAccount newUser){
            var db = new DataContext();
            db.Add(newUser);
            db.SaveChanges();
        }
    }
}
