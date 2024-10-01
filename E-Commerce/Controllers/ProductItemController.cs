using E_Commerce.DataAccessDataAccess.Repository.IRepository;
using E_Commerce.Models.Product;
using E_Commerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;

namespace E_Commerce.Controllers
{
    public class ProductItemController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductItemController(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            return View(unitOfWork.ProductItem.GetAll("Product").ToList());
        }

        /// Update and Insert
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ProductItemWithProductSelectListVM ProductItemVM = new ProductItemWithProductSelectListVM()
            {
                ProductItem = (id == 0 || id is null) ? unitOfWork.ProductItem.Get(pi => pi.Id == id, "Product") : new ProductItem(),
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

    }
}
