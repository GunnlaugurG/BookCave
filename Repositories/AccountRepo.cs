using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModel;
using BookCave.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Repositories
{
    public class AccountRepo
    {
        private DataContext _db;

        public AccountRepo()
        {
            _db = new DataContext();
        }

        public void addCardInfoToDataBase(CardInfo newCard)
        {
            _db.Add(newCard);
            _db.SaveChanges();
        }

        public void addUserToDataBase(UserAccount newUser)
        {
            _db.Add(newUser);
            _db.SaveChanges();
        }

        public void addShippingAddresToDataBase(ShippingInfo newShipping)
        {
            _db.Add(newShipping);
            _db.SaveChanges();
        }
        public void addCartToDatabase(Cart newCart){
            _db.Add(newCart);
            _db.SaveChanges();
        }
        public void addCartItemToDatabase(CartItem newCartItem){
            _db.Add(newCartItem);
            _db.SaveChanges();
        }
        public void addOrderToDataBase(Order orders){
            _db.Add(orders);
            _db.SaveChanges();
        }

        public AccountDetailsViewModel getUserDetailsFromDataBase(string userId)
        {
            var user = (from a in _db.userAccounts
                        where a.aspUserId == userId
                        select new AccountDetailsViewModel
                        {
                            userName = a.userName,
                            picture = a.picture,

                            address = (from b in _db.shipingInfo
                                       where b.aspUserIdForShipping == userId
                                       select b.address).FirstOrDefault(),
                            zipCode = (from b in _db.shipingInfo
                                       where b.aspUserIdForShipping == userId
                                       select b.zipCode).FirstOrDefault(),
                            city = (from b in _db.shipingInfo
                                    where b.aspUserIdForShipping == userId
                                    select b.city).FirstOrDefault(),
                            country = (from b in _db.shipingInfo
                                       where b.aspUserIdForShipping == userId
                                       select b.country).FirstOrDefault(),
                            cardholderName = (from c in _db.cardInfo
                                              where c.aspUserIdForCardInfo == userId
                                              select c.cardholderName).FirstOrDefault(),
                            cardNumber = (from c in _db.cardInfo
                                          where c.aspUserIdForCardInfo == userId
                                          select c.cardNumber).FirstOrDefault(),
                            favoriteBookName = "Not reddy"
                        }).FirstOrDefault();
            return user;
        }
        public void ChangeImageRepo( string userId, ChangeProfilePictureInputModel newImage ){

            var change = (from u in _db.userAccounts 
                            where u.aspUserId == userId
                            select u).FirstOrDefault();
            change.picture = newImage.picture;
            _db.SaveChanges();
        }
        public void ChangeShippingInfoRepo(string userId, ChangeShippingInputModel newShippingInfo)
        {
            var change = (from u in _db.shipingInfo
                          where u.aspUserIdForShipping == userId
                          select u).FirstOrDefault();
            if (change == null)
            {
                ShippingInfo shiping = new ShippingInfo
                {
                    address = newShippingInfo.address,
                    city = newShippingInfo.city,
                    country = newShippingInfo.country,
                    zipCode = newShippingInfo.zipCode,
                    aspUserIdForShipping = userId
                };
                addShippingAddresToDataBase(shiping);
            }
            else
            {
                change.address = newShippingInfo.address;
                change.city = newShippingInfo.city;
                change.country = newShippingInfo.country;
                change.zipCode = newShippingInfo.zipCode;
            }
            _db.SaveChanges();
        }

        public void changeCardInfoRepo(string UserId, ChangeCardInputModel newCard)
        {
            var change = (from a in _db.cardInfo
                          where a.aspUserIdForCardInfo == UserId
                          select a).FirstOrDefault();
            if (change == null)
            {
                CardInfo newCardInfo = new CardInfo
                {
                    cardholderName = newCard.cardholderName,
                    cardNumber = newCard.cardNumber,
                    cvc = newCard.cvc,
                    aspUserIdForCardInfo = UserId
                };
                addCardInfoToDataBase(newCardInfo);
            }
            else
            {
                change.cardholderName = newCard.cardholderName;
                change.cardNumber = newCard.cardNumber;
                change.cvc = newCard.cvc;
            }
            _db.SaveChanges();
        }
        /*public DisplayCartItemViewModel getBookRepo(int bookId){
            var newModel = new DisplayCartItemViewModel();
            newModel.BookName = (from a in _db.books
                        where a.Id == bookId
                        select a.title).FirstOrDefault();
            newModel.cost = (from a in _db.books
                            where a.Id == bookId
                            select a.cost).FirstOrDefault();
            newModel.bookId = bookId;
        return newModel;
        }*/
        public bool AddToCartRepo(int thisBookId, string userId){
            var userCart = (from c in _db.carts
                            where c.cartForUserId == userId && c.orderComplete == false
                            select c).FirstOrDefault();
            var getBook = (from b in _db.books
                            where b.Id == thisBookId
                            select b).FirstOrDefault();

            if(userCart == null){
                Cart newCart = new Cart
                {
                    totalCost = getBook.cost,
                    cartForUserId = userId,
                    quantityInCart = 1,
                    orderComplete = false
                };
                addCartToDatabase(newCart);
                CartItem newCartItem = new CartItem{
                    keyCartId = newCart.Id,
                    itemCost = getBook.cost,
                    bookQuantity = 1,
                    bookForCartItem = getBook.Id
                };
                addCartItemToDatabase(newCartItem);
                return true;
            }
            else{
                if(checkIfBookIsInCart(thisBookId, userCart.Id) == false){
                    return false;
                }
                userCart.quantityInCart += 1;
                userCart.totalCost += getBook.cost;
                CartItem addCartItem = new CartItem{
                    keyCartId = userCart.Id,
                    itemCost = getBook.cost,
                    bookQuantity = 1,
                    bookForCartItem = getBook.Id
                };
                addCartItemToDatabase(addCartItem);
                _db.SaveChanges();
                return true;
            }
        }
        public DisplayCartViewModel getCartViewModelRepo(string userId){
            var cartId = (from a in _db.carts
                            where a.cartForUserId == userId && a.orderComplete == false
                            select a.Id).FirstOrDefault();

            var newModel = new DisplayCartViewModel();

            newModel.booksList = new List<BookInCartListViewModel>();
            newModel.totalCost = (from a in _db.carts
                                    where a.cartForUserId == userId && a.orderComplete == false
                                    select  a.totalCost).FirstOrDefault();

            var listOfBookId = (from a in _db.cartItems
                                where a.keyCartId == cartId
                                select a.bookForCartItem).ToList();

            for(int i = 0; i < listOfBookId.Count; i++){
                newModel.booksList.Add((from a in _db.books
                                        where a.Id == listOfBookId[i]
                                        select new BookInCartListViewModel{
                                            id = a.Id,
                                            title = a.title,
                                            cost = a.cost,
                                            image = a.image
                                        }).FirstOrDefault());                    
            }
            return newModel;
        }
        public bool checkIfBookIsInCart(int bookId, string userCart){
            var cehckDb = (from a in _db.cartItems
                            where a.keyCartId == userCart && a.bookForCartItem == bookId
                            select a).FirstOrDefault();
            if(cehckDb == null){
                return true;
            }
            return false;
        }
        public CheckOutViewModel checkOutRepo(string userId){
            var newModel = new CheckOutViewModel();
            newModel.booksList = new List<BookInCartListViewModel>();
            //GETTING CART ID SO I CAN FIND EVERY ITEM THAT IS LINKED TO IT
            var cartId = (from a in _db.carts
                        where a.cartForUserId == userId && a.orderComplete == false
                        select a.Id).FirstOrDefault();
            //FILL IN VIEWMODEL FROM SHIPPING INFO
            var getUserDetails = (from a in _db.shipingInfo
                                    where a.aspUserIdForShipping == userId
                                    select a).FirstOrDefault();
            newModel.address = getUserDetails.address;
            newModel.city = getUserDetails.city;
            newModel.country = getUserDetails.country;
            newModel.zipCode = getUserDetails.zipCode;
            // FILL IN VIEW MODEL FROM SHIPPING INFO
            var cardInfo = (from b in _db.cardInfo
                            where b.aspUserIdForCardInfo == userId
                            select b).FirstOrDefault();
            newModel.cardHolderName = cardInfo.cardholderName;
            newModel.cardNumber = cardInfo.cardNumber;
            //FILL IN TOTALCOST
            newModel.totalCost = (from a in _db.carts
                                where a.cartForUserId == userId
                                select a.totalCost).FirstOrDefault();
            //FINDING BOOK ID AND QUANTITY OF THAT BOOK 
            var newList = new List<CartItemAndBookConnection>();
            var findConnection = (from a in _db.cartItems
                        where a.keyCartId == cartId
                        select a).ToList();
            //merging togather book it and quantity to list
            foreach(var connection in findConnection){
                CartItemAndBookConnection cartItemToList = new CartItemAndBookConnection();
                cartItemToList.bookId = connection.bookForCartItem;
                cartItemToList.quantity = connection.bookQuantity;
                newList.Add(cartItemToList);
            }
            //adding to the ViewModel List with the merger
            foreach(var a in newList){
                var b = (from c in _db.books
                        where c.Id == a.bookId
                        select new BookInCartListViewModel{
                            quantity = a.quantity,
                            id = c.Id,
                            title = c.title,
                            cost = c.cost,
                            image = c.image
                        }).FirstOrDefault();
                newModel.booksList.Add(b);
            }

            return newModel;
        }
        public bool completeRepo(string userID){
            Order newOrder = new Order{
                aspForCartId = userID
            };
            var changeCart = (from a in _db.carts
                            where a.cartForUserId == userID
                            select a).FirstOrDefault();
            changeCart.totalCost = 0;
            addOrderToDataBase(newOrder);
            var cartId = (from a in _db.carts
                            where a.cartForUserId == userID
                            select a.Id).FirstOrDefault();
            var listOfItems = (from a in _db.cartItems
                                where a.keyCartId == cartId
                                select a).ToList();
            for(int i = 0; i < listOfItems.Count; i++){
                listOfItems[i].keyCartId = newOrder.Id;
            }
            _db.SaveChanges();
            return true;
        }
    }
}