using E_Commerce.DataAccessDataAccess.Repository.IRepository;
using E_Commerce.Models.OrderFile;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List <Order> orders=_unitOfWork.Order.GetAll(includeProperties:"User").ToList();
            return View(orders);
        }

      
    }
}

