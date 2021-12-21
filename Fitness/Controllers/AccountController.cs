using Fitness.Models;
using Fitness.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _singInManager;
       //RoleManager<ApplicationUser> _roleManager;      

        public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager)// RoleManager<ApplicationUser> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _singInManager = singInManager;
          // _roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _singInManager.PasswordSignInAsync(model.UserName,model.Password,model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неправильні данні");
            }
            return View(model);
        }

        public async Task<IActionResult> Register()
        {
            //if (!_roleManager.RoleExistsAsync(Helper.userRole).GetAwaiter().GetResult())
            //{
            //    await _roleManager.CreateAsync(new IdentityRole(Helper.userRole));
            //}
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    Height = model.Height,
                    Weight = model.Weight,
                    Birth = model.Birth,
                    Registration = DateTime.Today,
                    GenderId = model.GenderId
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //await _userManager.AddToRoleAsync(user, "Сonsumer");
                    await _singInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> LogOff()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        
    }
}
