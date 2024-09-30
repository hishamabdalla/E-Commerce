using E_Commerce.Models.ViewModels;
using E_Commerce.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ProductWithCategorySelectListVM productVM = new()
            {
                Product = (id != 0 || id is not null) ? new Product(): new Product(),
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
                }
                // add
                // save
                return RedirectToAction(nameof(Index));
            }
            // categorylist
            return View(productVM);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            // get
            return View();
        }

        [HttpPost, ActionName("DeleteBehavior")]
        public IActionResult DeleteProduct(int id)
        {
            // delete
            return RedirectToAction(nameof(Index));
        }
    }
}
