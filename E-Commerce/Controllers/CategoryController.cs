using E_Commerce.DataAccessDataAccess.Repository.IRepository;
using E_Commerce.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Controllers
{
    [Authorize(Roles ="Admin")]
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

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> ParentCategoryList = _unitOfWork.Category.GetAll("ParentCategory")
              .Select(u => new SelectListItem
              {
                  Text = u.Name,
                  Value = u.Id.ToString()

              });
            ViewBag.ParentCategoryList = ParentCategoryList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Category.Get(c => c.Id == id);

            IEnumerable<SelectListItem> ParentCategoryList = _unitOfWork.Category.GetAll( "ParentCategory")
             .Select(u => new SelectListItem
             {
                 Text = u.Name,
                 Value = u.Id.ToString()

             });
            ViewBag.ParentCategoryList = ParentCategoryList;
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
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
