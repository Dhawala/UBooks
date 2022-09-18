using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using UBooks.DataAccess;
using UBooks.DataAccess.Repository.IRepository;
using UBooks.Models;

namespace UBooksWeb.Controllers
{
    public class CategoryController : Controller
    {
        IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _unitOfWork.Category.GetAll();
            return View(CategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name cannot be equal to Display order");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _unitOfWork.Category.GetFirstOrDefault(i => i.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name cannot be equal to Display order");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpGet,ActionName("Delete")]
        public IActionResult Delete(int id) 
        {
            if (id != null || id != 0)
            {
                Category category = _unitOfWork.Category.GetFirstOrDefault(i => i.Id == id);
                if (category != null)
                {
                    _unitOfWork.Category.Remove(category);
                    _unitOfWork.Save();
                    TempData["Success"] = "Deleted Successfully";
                    return RedirectToAction("Index");
                }
                else {
                    return NotFound();
                }
            }
            else {
                return NotFound();
            }
        }
    }
}
