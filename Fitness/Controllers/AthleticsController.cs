using Fitness.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Controllers
{
    public class AthleticsController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;

        public AthleticsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IEnumerable<Athletics> GetAthletics()
        {
            var athletics = (from athletic in _db.Athleticss
                         join exercise in _db.Exercises on athletic.ExerciseId equals exercise.Id
                         join users in _db.Users.Where(u => u.Id == _userManager.GetUserId(HttpContext.User)) on athletic.UserId equals users.Id
                         select new Athletics
                         {
                             Id = athletic.Id,
                             UserId = athletic.UserId,
                             ExerciseId = athletic.ExerciseId,
                             Duration = athletic.Duration,
                             Timeofday = athletic.Timeofday
                         }
                         ).ToList();

            return athletics;
        }

        public IActionResult AthleticsIndex()
        {
            IEnumerable<Athletics> objList = GetAthletics();
            foreach (var obj in objList)
            {
                obj.Exercise = _db.Exercises.FirstOrDefault(u => u.Id == obj.ExerciseId);
            }
            return View(objList);
        }

        // GET-Create
        public IActionResult AthleticsCreate()
        {
            IEnumerable<SelectListItem> AthleticsDropDown = _db.Exercises.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.AthleticsDropDown = AthleticsDropDown;

            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AthleticsCreate(Athletics model)
        {
            var athletics = new Athletics
            {
                UserId = _userManager.GetUserId(HttpContext.User),
                ExerciseId = model.ExerciseId,
                Duration = model.Duration,
                Timeofday = model.Timeofday,
            };

            _db.Athleticss.Add(athletics);
            _db.SaveChanges();
            return RedirectToAction("AthleticsIndex");
        }
    }
}
