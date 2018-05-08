using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModel;
using BookCave.Models.ViewModels;
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
    }
}