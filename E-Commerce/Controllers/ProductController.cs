﻿using E_Commerce.Models.ViewModels;
using E_Commerce.Models.Product;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.DataAccessDataAccess.Repository.IRepository;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(unitOfWork.Product.GetAll());
        }
        // comment
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ProductWithCategorySelectListVM productVM = new()
            {
                Product = (id != 0 || id is not null) ? unitOfWork.Product.Get(p => p.Id == id): new Product(),
                // categorylist
            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Upsert(ProductWithCategorySelectListVM productVM)
        {
            if (ModelState.IsValid)
            {
                if(productVM.Product.Id != 0)
                {
                    //update
                    unitOfWork.Product.Update(productVM.Product);
                    TempData["Update"] = "Product Updated Successfully";

                }
                else
                {
                    // add
                    unitOfWork.Product.Add(productVM.Product);
                    TempData["Success"] = "Product created Successfully";
                }
               
                // save
                unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            // categorylist
            return View(productVM);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Product product = unitOfWork.Product.Get(p => p.Id == id);
            if (product is null)
                return NotFound();
            
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteProduct(int id)
        {
            // delete
            Product product = unitOfWork.Product.Get(c => c.Id == id);
            unitOfWork.Product.Remove(product);
            TempData["Success"] = "Product deleted Successfully";
            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
