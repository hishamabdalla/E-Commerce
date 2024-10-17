using E_Commerce.DataAccessDataAccess.Repository.IRepository;
using E_Commerce.Models.OrderFile;
using E_Commerce.Models.ShoppingCartFile;
using E_Commerce.Models.ViewModels;
using E_Commerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    // i didn't put this in the area of customer so when you copy paste that to the customer area uncomment this
    //[Area("customer")]

    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicaitonUserId == UserId, includeProperties:"ProductItem"),
                Order=new()
               
                
            };
            
            /// Calculating the total price
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                
                cart.Price = cart.ProductItem.Price * cart.Quantity; // if you want to view every shopping cart item specific price
                ShoppingCartVM.Order.TotalPrice += (cart.ProductItem.Price * cart.Quantity);
            }

            return View(ShoppingCartVM);
        }

        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicaitonUserId == UserId, includeProperties: "ProductItem"),
                Order = new()
            };
            ShoppingCartVM.Order.User = _unitOfWork.User.Get(u => u.Id == UserId);

            ShoppingCartVM.Order.Name = ShoppingCartVM.Order.User.FirstName + " " + ShoppingCartVM.Order.User.LastName;
            ShoppingCartVM.Order.PhoneNumber = ShoppingCartVM.Order.User.PhoneNumber;
            ShoppingCartVM.Order.StreetAddress = ShoppingCartVM.Order.User.StreetAddress;
            ShoppingCartVM.Order.City = ShoppingCartVM.Order.User.City;
            ShoppingCartVM.Order.State = ShoppingCartVM.Order.User.State;
            ShoppingCartVM.Order.PostalCode = ShoppingCartVM.Order.User.PostalCode;

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {

                cart.Price = cart.ProductItem.Price * cart.Quantity; // if you want to view every shopping cart item specific price
                ShoppingCartVM.Order.TotalPrice += (cart.ProductItem.Price * cart.Quantity);
            }
            ShoppingCartVM.Order.PaymentStatus = SD.PaymentStatusPending;
            ShoppingCartVM.Order.OrderStatuss = SD.StatusPending;

            _unitOfWork.Order.Add(ShoppingCartVM.Order);
            _unitOfWork.Save();
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                OrderLine orderDetail = new()
                {
                    ProductItemId = cart.ProductItemId,
                    OrderId = ShoppingCartVM.Order.Id,
                    Price = cart.Price,
                    Quantity = cart.Quantity
                };
                _unitOfWork.OrderLine.Add(orderDetail);
                _unitOfWork.Save();
            }
            return View(ShoppingCartVM);
        }
        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicaitonUserId == UserId, includeProperties: "ProductItem");
            ShoppingCartVM.Order.OrderDate = System.DateTime.Now;
            ShoppingCartVM.Order.UserId = UserId;
            ShoppingCartVM.Order.User = _unitOfWork.User.Get(u => u.Id == UserId);

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {

                cart.Price = cart.ProductItem.Price * cart.Quantity; // if you want to view every shopping cart item specific price
                ShoppingCartVM.Order.TotalPrice += (cart.ProductItem.Price * cart.Quantity);
            }
            return View(ShoppingCartVM);
        }

        public IActionResult Plus(int CartId) 
        {
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == CartId);
            cartFromDb.Quantity += 1;
            _unitOfWork.ShoppingCart.Update(cartFromDb);
           _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Minus(int CartId)
        {
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == CartId);
            if(cartFromDb.Quantity <= 1)
            {
                _unitOfWork.ShoppingCart.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Quantity -= 1;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }

            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int CartId)
        {
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == CartId);
            _unitOfWork.ShoppingCart.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
