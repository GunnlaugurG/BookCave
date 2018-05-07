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
        private BookRepo _bookRepo;
        public AccountServices(){
           _accountRepo  = new AccountRepo();
           _bookRepo = new BookRepo();
        }

        public void addNewUserToDataBase(ApplicationUser user){
            UserAccount _user = new UserAccount();
                _user.userName = user.Email;
                _user.aspUserId = user.Id;
                _user.picture = "https://image.freepik.com/free-icon/male-user-shadow_318-34042.jpg";
                _user.password = "Óskráð";
                _user.cardInfo = new CardInfo { cardholderName = "Óskráð",
                                                cardNumber = "Óskráð"};
                _user.favoriteBook = _bookRepo.getFavoriteBook();
                _user.shippingInfo = new ShippingInfo { address = "Óskráð",
                                                        city = "Óskráð",
                                                        country = "Óskráð",
                                                        zipCode = 111};

                _accountRepo.addUserToDataBase(_user);
        }

        public AccountDetailsViewModel getUserDetails(string userID){
            var userDetails = _accountRepo.getUserDetailsFromDataBase(userID);
            
            return userDetails;
        }
    }
}
