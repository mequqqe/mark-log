using EnglishPractice.Data;
using EnglishPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnglishPractice.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product>objList = _db.Product;
            foreach(var obj in objList)
            {
                obj.Category = _db.Category.FirstOrDefault(u => u.Id == obj.CategoryId);
            };
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryDropDown = _db.Category.Select(i=> new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            //ViewBag.CategoryDropDown = CategoryDropDown;

            ViewData["CategoryDropDown"] = CategoryDropDown;
            Product product = new Product();
            if(id == null) 
            {
                return View(product);
            }
            else
            {
                product = _db.Product.Find(id);
                if(product == null) 
                {
                    return(NotFound());
                }
                return View(product);
            }
            return View();
        }

        //POST-Upsert//

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category obj)
        {
            if (ModelState.IsValid) 
            {
                _db.Category.Add(obj);
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
