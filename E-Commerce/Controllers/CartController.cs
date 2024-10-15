using E_Commerce.DataAccessDataAccess.Repository.IRepository;
using E_Commerce.Models.ShoppingCartFile;
using E_Commerce.Models.ViewModels;
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
        private readonly IUnitOfWork unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList = unitOfWork.ShoppingCart.GetAll(u => u.ApplicaitonUserId == UserId, includeProperties:"ProductItem"),
                OrderTotal = 0
            };
            
            /// Calculating the total price
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                
                cart.Price = cart.ProductItem.Price * cart.Quantity; // if you want to view every shopping cart item specific price
                ShoppingCartVM.OrderTotal += (cart.ProductItem.Price * cart.Quantity);
            }

            return View(ShoppingCartVM);
        }

        public IActionResult Summary()
        {
            return View();
        }

        public IActionResult Plus(int CartId)
        {
            ShoppingCart cartFromDb = unitOfWork.ShoppingCart.Get(u => u.Id == CartId);
            cartFromDb.Quantity += 1;
            unitOfWork.ShoppingCart.Update(cartFromDb);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Minus(int CartId)
        {
            ShoppingCart cartFromDb = unitOfWork.ShoppingCart.Get(u => u.Id == CartId);
            if(cartFromDb.Quantity <= 1)
            {
                unitOfWork.ShoppingCart.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Quantity -= 1;
                unitOfWork.ShoppingCart.Update(cartFromDb);
            }

            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int CartId)
        {
            ShoppingCart cartFromDb = unitOfWork.ShoppingCart.Get(u => u.Id == CartId);
            unitOfWork.ShoppingCart.Remove(cartFromDb);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
