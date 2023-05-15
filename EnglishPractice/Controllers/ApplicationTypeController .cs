using EnglishPractice.Data;
using EnglishPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnglishPractice.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //POST-Create//

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET-Edit//

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.ApplicationType.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-Edit//

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(obj);
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
            var obj = _db.ApplicationType.Find(Id);
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
            var obj = _db.ApplicationType.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ApplicationType.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            return View(obj);
        }


        public IActionResult List(ApplicationType obj)
        {
            var ApplicationType = _db.ApplicationType.ToList();
            return View(ApplicationType);

        }

        public IActionResult Notice(int? Id)
        {
             if (Id == null || Id == 0)
                {
                    return NotFound();
                }
                var obj = _db.ApplicationType.Find(Id);
                if (obj == null)
                {
                    return NotFound();
                }
                return View(obj);
        }

        [Route("day-visit")]
        public async Task<IActionResult> UpdateDayAsync(int studentId, int day, bool isVisit)
        {
            var result = await _db.DayVisit.FirstOrDefaultAsync(x => x.Day == day && x.SrudentId == studentId);
            result.IsVisit = isVisit;
            await _db.SaveChangesAsync();
            return Ok();
        }

    }
}
