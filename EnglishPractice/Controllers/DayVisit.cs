using EnglishPractice.Data;
using EnglishPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnglishPractice.Controllers
{
    public class DayVisit : Controller
    {
        private readonly DayVisit _db;

        public DayVisit(DayVisit db)
        {
            _db = db;
        }

       public async Task UpdateCheckBox(int Day,int StudentId,bool IsVisit)
        {
            var data = _db.UpdateCheckBox(Day, StudentId, IsVisit);
        }

    }
}
