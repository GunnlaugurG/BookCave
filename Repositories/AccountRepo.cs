using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModel;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class AccountRepo
    {
        private DataContext _db;
        
        public AccountRepo(){
            _db = new DataContext();    
        }
        public void addUserToDataBase(UserAccount newUser){
            
            _db.Add(newUser);
            _db.SaveChanges();
        }

        public AccountDetailsViewModel getUserDetailsFromDataBase(string userId){

                var user = (from a in _db.userAccounts
                            where a.aspUserId == userId
                            select new AccountDetailsViewModel{

                                
                                userName = a.userName,
                                picture = a.picture,
                                //ÞARF AÐ KLARA HER
                            }).FirstOrDefault();
           return user;
        }

        public void ChangeShippingInfoRepo(string userId, ChangeShippingInputModel newShippingInfo){
            var change = (from u in _db.userAccounts
                            where u.aspUserId == userId
                            select u).FirstOrDefault();
            
            
            
            //_db.SaveChanges();

                             
        }
    }
}
