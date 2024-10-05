using E_Commerce.DataAccessDataAccess.Repository.IRepository;
using E_Commerce.Models.Product;
using E_Commerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> CategoryList = _unitOfWork.Category.GetAll().ToList();
          
            return View(CategoryList);
        }

        public IActionResult Upsert(int? id)
        {
            CategoryVM categoryVM = new()
            {
                Category = (id == 0 || id !=null) ? _unitOfWork.Category.Get(c => c.Id == id, "ParentCategory") : new Category(),
                CategoryList = _unitOfWork.Category.GetAll("ParentCategory").Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Name
                }),

            };
            
            return View(categoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                if (categoryVM.Category.Id != 0)
                {
                    _unitOfWork.Category.Update(categoryVM.Category);
                    TempData["success"] = "Category Updated Successfully";
                    
                }
                else
                {
                    _unitOfWork.Category.Add(categoryVM.Category);
                    TempData["success"] = "Category Created Successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            categoryVM.CategoryList = _unitOfWork.Category.GetAll("ParentCategory").Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Name
            });

            return View(categoryVM);
        }
        
        
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Category.Get(c => c.Id == id, "ParentCategory");
          
            
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var categoryFromDb = _unitOfWork.Category.Get(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");

        }
    }
}
