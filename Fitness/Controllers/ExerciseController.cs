using Fitness.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExerciseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult ExerciseIndex()
        {
            IEnumerable<Exercise> objList = _db.Exercises;

            return View(objList);
        }

        public IActionResult ExerciseCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExerciseCreate(Exercise model)
        {
            if (ModelState.IsValid)
            {
                var exercise = new Exercise
                {
                    Name = model.Name,
                    CaloriesPerMinute = model.CaloriesPerMinute,
                };

                _db.Exercises.Add(exercise);
                _db.SaveChanges();
                return RedirectToAction("ExerciseIndex");
            }
            return View(model);
        }

        // GET Delete
        public IActionResult ExerciseDelete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Exercises.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExerciseDeletePost(int? id)
        {
            var obj = _db.Exercises.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Exercises.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("ExerciseIndex");

        }

        // GET Update
        public IActionResult ExerciseUpdate(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var exercise = _db.Exercises.Find(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return View(exercise);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExerciseUpdate(Exercise model)
        {
            if (ModelState.IsValid)
            {
                _db.Exercises.Update(model);
                _db.SaveChanges();
                return RedirectToAction("ExerciseIndex");
            }
            return View(model);
        }
    }
}
