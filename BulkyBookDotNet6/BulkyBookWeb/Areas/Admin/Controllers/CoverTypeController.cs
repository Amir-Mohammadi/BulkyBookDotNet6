
using BulkBook.DataAccess.Repository;
using BulkBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
[Area("Admin")]
    public class CoverTyoeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTyoeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        //Get
        public IActionResult Create()
        {
           
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
          
            if (ModelState.IsValid)
            {

            _unitOfWork.CoverType.Add(obj);
            _unitOfWork.Save();
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
            var coverTypeFormDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverTypeFormDbFirst == null)
            {
                return NotFound();
            }

            return View(coverTypeFormDbFirst);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
        
            if (ModelState.IsValid)
            {

                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
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
            var coverTypeFormDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverTypeFormDbFirst == null)
            {
                return NotFound();
            }

            return View(coverTypeFormDbFirst);
        }
        //delete    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                _unitOfWork.CoverType.Remove(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


         
    }
}
