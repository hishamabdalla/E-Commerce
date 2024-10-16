﻿using E_Commerce.DataAccessDataAccess.Repository.IRepository;
using E_Commerce.Models.Product;
using E_Commerce.Models.ShoppingCartFile;
using E_Commerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize]

    public class ProductItemController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductItemController(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            return View(unitOfWork.ProductItem.GetAll(includeProperties: "Product").ToList());
        }

        /// Update and Insert
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ProductItemWithProductSelectListVM ProductItemVM = new ProductItemWithProductSelectListVM()
            {
                ProductItem = (id == 0 || id is not null) ? unitOfWork.ProductItem.Get(pi => pi.Id == id, "Product") : new ProductItem(),
                ProductList = unitOfWork.Product.GetAll().Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() })

            };
            return View(ProductItemVM);
        }

        [HttpPost]
        public IActionResult Upsert(ProductItemWithProductSelectListVM ProductItemVM)
        {
            if (ModelState.IsValid)
            {
                // update
                if(ProductItemVM.ProductItem.Id != 0)
                {
                    unitOfWork.ProductItem.Update(ProductItemVM.ProductItem);
                    TempData["Update"] = "Product Item Updated Successfully";
                }
                else
                {
                    // add
                    unitOfWork.ProductItem.Add(ProductItemVM.ProductItem);
                    TempData["Success"] = "Product Item created Successfully";

                }

                unitOfWork.Save();
                return RedirectToAction("Index");

            }
            /// Product List
            ProductItemVM.ProductList = unitOfWork.Product.GetAll().Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() });

            return View(ProductItemVM);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ProductItem productItem = unitOfWork.ProductItem.Get(pi => pi.Id == id, "Product");
            if(productItem is null)
            {
                return NotFound();
            }
            return View(productItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteProductItem(int id)
        {
            ProductItem productItem = unitOfWork.ProductItem.Get(pi => pi.Id == id);
            unitOfWork.ProductItem.Remove(productItem);
            TempData["Success"] = "Product Item deleted Successfully";
            unitOfWork.Save();
            return RedirectToAction("Index");

        }

        public IActionResult Details(int Id)
        {
            ProductItem P = unitOfWork.ProductItem.Get(p => p.Id == Id, "Product");
            if (P is null)
                return NotFound();


            return View(P);
        }


        public IActionResult AddToCart(int Id)
        {
            ProductItem ProductItem = unitOfWork.ProductItem.Get(p => p.Id == Id, "Product");

            ShoppingCart cart = new()
            {
                ProductItem = ProductItem,
                Quantity = 1,
                ProductItemId = Id
            };

            if (cart.ProductItem == null)
                return NotFound();

            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult ConfirmAddToCart(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicaitonUserId = UserId;

            /// Checking if the user add some product multiple times but in difference requests
            /// 

            ShoppingCart cartFromDb = unitOfWork.ShoppingCart.Get(s => s.ApplicaitonUserId == UserId && s.ProductItemId == shoppingCart.ProductItemId);

            if(cartFromDb != null)
            {
                // Shopping Cart Exists
                cartFromDb.Quantity += shoppingCart.Quantity;
                unitOfWork.ShoppingCart.Update(cartFromDb);
            }
            else
            {
                // Add Cart Record
                unitOfWork.ShoppingCart.Add(shoppingCart);
            }

            unitOfWork.Save();

            return RedirectToAction("Index", "ProductItem"); // ActionName, ControllerName
        }
    }
}
