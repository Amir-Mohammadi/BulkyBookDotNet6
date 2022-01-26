using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {
           
            return View();
        }
<<<<<<< Updated upstream
=======

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

            _db.Categories.Add(obj);
            _db.SaveChanges();
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
            var categoryFormDb = _db.Categories.Find(id);
            //var categoryFormDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFormDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFormDb == null)
            {
                return NotFound();
            }

            return View(categoryFormDb);
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

                _db.Categories.Update(obj);
                _db.SaveChanges();
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
            var categoryFormDb = _db.Categories.Find(id);
            //var categoryFormDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFormDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFormDb == null)
            {
                return NotFound();
            }

            return View(categoryFormDb);
        }
        //delete    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
            return View(obj);
        }



>>>>>>> Stashed changes
    }
}
