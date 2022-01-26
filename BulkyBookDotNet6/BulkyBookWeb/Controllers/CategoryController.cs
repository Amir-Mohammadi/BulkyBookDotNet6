
using BulkBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.GetAll();
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {
           
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrderCannot exatly Match The Name");
            }
            if (ModelState.IsValid)
            {

            _db.Add(obj);
            _db.Save();
            return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFormDb = _db.Categories.Find(id);
            var categoryFormDbFirst = _db.GetFirstOrDefault(u => u.Id == id);
            //var categoryFormDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFormDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFormDbFirst);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrderCannot exatly Match The Name");
            }
            if (ModelState.IsValid)
            {

                _db.Update(obj);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }




        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFormDb = _db.Categories.Find(id);
            var categoryFormDbFirst = _db.GetFirstOrDefault(u => u.Id == id);
            //var categoryFormDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFormDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFormDbFirst);
        }
        //delete    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Remove(obj);
                _db.Save();
                return RedirectToAction("Index");
            
            return View(obj);
        }



    }
}
