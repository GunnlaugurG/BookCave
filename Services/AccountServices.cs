using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data.EntityModels;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class AccountServices
    {
        private AccountRepo _accountRepo;
        public AccountServices(){
           _accountRepo  = new AccountRepo();
        }
        


        public void addNewUserToDataBase(ApplicationUser user){
            UserAccount _user = new UserAccount();
                _user.userName = user.Email;
                _user.aspUserId = user.Id;

                _accountRepo.addUserToDataBase(_user);
        }

        public AccountDetailsViewModel getUserDetails(string userID){
            var userDetails = _accountRepo.getUserDetailsFromDataBase(userID);
            
            return userDetails;
        }
    }
}
