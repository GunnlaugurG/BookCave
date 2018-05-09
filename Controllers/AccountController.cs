using BookCave.Models;
using BookCave.Models.InputModel;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookCave.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        private AccountServices _accountServices = new AccountServices();

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) { return View(); }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //The user is successfully registerd
                //Add the concantenated first name as Fullname
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));
                await _signInManager.SignInAsync(user, false);

                _accountServices.addNewUserToDataBase(user);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) { return View(); }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Details()
        {
            var user = await GetCurrentUserAsync();

            var userId = user?.Id;
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var _userInfo = _accountServices.getUserDetails(userId);
            return View(_userInfo);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeShippingDetails(ChangeShippingInputModel changeShipping)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                var userId = user?.Id;
                if (userId == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                _accountServices.changeShippingInfoServ(userId, changeShipping);

                return RedirectToAction("Details", "Account");
            }
            return RedirectToAction("Details", "Account");
        }
        public async Task<IActionResult> ChangeProfilePicture(ChangeProfilePictureInputModel newImage){

            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                var userId = user?.Id;
                if (userId == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                _accountServices.changeImageServ(userId, newImage);
            }
            return RedirectToAction("Details", "Account");
        }
        public async Task<IActionResult> ChangeCardDetails(ChangeCardInputModel ChangeCardInfo)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                var userId = user?.Id;
                if (userId == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                _accountServices.cahngeCardServ(userId, ChangeCardInfo);
            }

            return RedirectToAction("Details", "Account");
        }
        
        public async Task<IActionResult> AddToCart(int Id){
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            if(userId == null){
                return RedirectToAction("Login", "Account");
            }
            else{
                bool added = _accountServices.AddToCart(Id, userId);
                return Ok();
            }
        }
        public async Task<IActionResult> RemoveFromCart( int bookId ){
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            if(userId == null){
                return RedirectToAction("Login", "Account");
            } 
            _accountServices.RemoveFromCartServ(bookId, userId);
            return Ok();
        }
        public async Task<IActionResult> Cart(){
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            if(userId == null){
                return RedirectToAction("Login", "Account");
            }
            var newModel = new DisplayCartViewModel();
            newModel = _accountServices.getCartviewModel(userId);
            return View(newModel);
        }
        public async Task<IActionResult> WishList(){
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            if(userId == null){
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public async Task<IActionResult> CheckOut(){
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            if(userId == null){
                return RedirectToAction("Login", "Account");
            }
            var checkInfo = _accountServices.checkPersonalInfo(userId);
            if(checkInfo != true){
                return RedirectToAction("ChangeInfo", "Account");
            }
            //EF PERSONU UPPL'YSINGAR ERU NULL ÞA KEMUR VILLA ÞARF AÐ LAGA
            var newModel = _accountServices.checkOutService(userId);
            
                return View(newModel);
        }
        public async Task<IActionResult> Complete(){
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            if(userId == null){
                return RedirectToAction("Login", "Account");
            }
            var success = _accountServices.completeServ(userId);
            return View("OrderSuccessful");
        }
                
        [HttpPost]
        public async Task<IActionResult> ChangeShippingDetailsInCart(ChangeShippingInputModel changeShipping)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                var userId = user?.Id;
                if (userId == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                _accountServices.changeShippingInfoServ(userId, changeShipping);

                return RedirectToAction("CheckOut", "Account");
            }
            return RedirectToAction("CheckOut", "Account");
        }
        public async Task<IActionResult> ChangeCardDetailsInCart(ChangeCardInputModel ChangeCardInfo)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                var userId = user?.Id;
                if (userId == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                _accountServices.cahngeCardServ(userId, ChangeCardInfo);
            }

            return RedirectToAction("CheckOut", "Account");
        }
        public async Task<IActionResult> ChangeInfo(){
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            if(userId == null){
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public async Task<IActionResult> OrderHistory(){
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            if(userId == null){
                return RedirectToAction("Login", "Account");
            }
            var orderList = new List<BooksInOrderHistoryViewModel>();
            orderList = _accountServices.OrderHistoryServ(userId);
            return View(orderList);
        }
    }
}