using EnglishPractice.Data;
using EnglishPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnglishPractice.Controllers
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
            IEnumerable<Category>objList = _db.Category;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //POST-Create//

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid) 
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(obj);
        }


        //GET-Edit//
        
        public IActionResult Edit(int? Id) 
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(Id);
            if (obj == null) 
            {
                return NotFound();
            }
            return View(obj);   
        }

        //POST-Edit//

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        //GET-Delete//

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-Delete//

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Category.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Category.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            return View(obj);
        }

    }
}
