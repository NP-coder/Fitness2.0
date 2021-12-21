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
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;

        public FoodController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
             _userManager = userManager;
        }

        public IEnumerable<Food> GetFoods()
        {
            var foods = (from food in _db.Foods
                         join product in _db.Products on food.ProductId equals product.Id
                         join users in _db.Users.Where(u => u.Id == _userManager.GetUserId(HttpContext.User)) on food.UserId equals users.Id
                         select new Food
                         {
                             Id = food.Id,
                             UserId = food.UserId,
                             ProductId = food.ProductId,
                             Number = food.Number,
                             Timeofday = food.Timeofday
                         }
                         ).ToList();

            return foods;
        }

        public IActionResult FoodIndex()
        {
            IEnumerable<Food> objList = GetFoods();
            foreach(var obj in objList)
            {
                obj.Product = _db.Products.FirstOrDefault(u => u.Id == obj.ProductId);
            }
            return View(objList); 
        }

        // GET-Create
        public IActionResult FoodCreate()
        {
            IEnumerable<SelectListItem> FoodDropDown = _db.Products.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.FoodDropDown = FoodDropDown;

            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FoodCreate(Food model)
        {

            var food = new Food
            {
                // User = _db.Users.Find(_userManager.GetUserAsync(HttpContext.User)),
                UserId = _userManager.GetUserId(HttpContext.User),
                ProductId = model.ProductId,
                Number = model.Number,
                Timeofday = model.Timeofday,  
            };

            _db.Foods.Add(food);
            _db.SaveChanges();
            return RedirectToAction("FoodIndex");                        
        }
    }
}
