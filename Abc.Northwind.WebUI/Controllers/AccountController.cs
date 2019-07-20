using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.WebUI.Entities;
using Abc.Northwind.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Abc.Northwind.WebUI.Controllers
{
    public class AccountController:Controller
    {
        private UserManager<CustomerIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomerIdentityUser> _signInManager;

        public AccountController(UserManager<CustomerIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomerIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public ActionResult Register()
        {

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registeRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomerIdentityUser user = new CustomerIdentityUser
                {
                    UserName = registeRegisterViewModel.UserName,
                    Email = registeRegisterViewModel.Email
                };
                IdentityResult result = _userManager.CreateAsync(user, registeRegisterViewModel.Password).Result;
                if (result.Succeeded)
                {
                    if (expr)
                    {
                        
                    }
                }
            }

         

        }
    }
}
