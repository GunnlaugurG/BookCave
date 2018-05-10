using System.Collections.Generic;
using BookCave.Data.EntityModels;
using BookCave.Models;
using BookCave.Models.InputModel;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class AccountServices
    {
        private AccountRepo _accountRepo;
        private BookRepo _bookRepo;

        public AccountServices()
        {
            _accountRepo = new AccountRepo();
            _bookRepo = new BookRepo();
        }

        public void addNewUserToDataBase(ApplicationUser user)
        {
            UserAccount _user = new UserAccount();
            _user.userName = user.Email;
            _user.aspUserId = user.Id;
            _user.picture = "https://image.freepik.com/free-icon/male-user-shadow_318-34042.jpg";
            _accountRepo.addUserToDataBase(_user);
        }

        public AccountDetailsViewModel getUserDetails(string userID)
        {
            var userDetails = _accountRepo.getUserDetailsFromDataBase(userID);
            return userDetails;
        }
        public void setFavoriteBook(int bookId, string userId ){
            _accountRepo.changeFavoriteBook(bookId, userId);
        }

        public void changeImageServ(string UserId, ChangeProfilePictureInputModel newImage){
            _accountRepo.ChangeImageRepo(UserId, newImage );
        }
        public void changeShippingInfoServ(string UserId, ChangeShippingInputModel newShipInfoService)
        {
            _accountRepo.ChangeShippingInfoRepo(UserId, newShipInfoService);
        }

        public void cahngeCardServ(string userId, ChangeCardInputModel newCardInfo)
        {
            _accountRepo.changeCardInfoRepo(userId, newCardInfo);
        }
        public bool AddToCart(int bookId, string userId){
            return _accountRepo.AddToCartRepo(bookId, userId);
        }
        public DisplayCartViewModel getCartviewModel(string UserId){
            var newModel = _accountRepo.getCartViewModelRepo(UserId);

            return newModel;
        }
        public CheckOutViewModel checkOutService(string userId){
            var newModel = _accountRepo.checkOutRepo(userId);
            return newModel;
        }
        public bool completeServ(string userId){
            var success = _accountRepo.completeRepo(userId);
            return success;
        }
        public bool checkPersonalInfo(string userId){
            var check = _accountRepo.checkIfUserHasInfo(userId);
            return check;
        }
        public void RemoveFromCartServ(int bookId, string userId){
            _accountRepo.RemovFromCartRepo(bookId, userId);
        }
        public void UpdateCartItemQuantity(int quantity,int bookId, string userId){
            _accountRepo.UpdateCartItemQuantity(quantity, bookId, userId);
        }
        public List<BooksInOrderHistoryViewModel>  OrderHistoryServ(string userId){
            var newModel = _accountRepo.OrderHistoryRepo(userId);
            return newModel;
        }
        public void EmptyCartFromServ(string userId) {
            _accountRepo.EmptyCartFromRepo(userId);
        }

        public List<WishListViewModel> GetWishList(string userId) {
            return _accountRepo.GetWishList(userId);
        }
        public void RemoveFromWishList(int id , string userId){
            _accountRepo.RemoveFromWishList(id, userId);
        }
        public void AddToWishList(int id, string userId) {
            _accountRepo.addBookToWishList(id,userId);
        }
    }
} 