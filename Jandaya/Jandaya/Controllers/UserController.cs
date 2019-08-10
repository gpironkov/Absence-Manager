﻿namespace Jandaya.Controllers
{
    using Jandaya.Common;
    using Jandaya.Services;
    using Jandaya.Data;
    using Jandaya.Data.Models;
    using Jandaya.Data.Models.BindingModels;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Linq;
    using System.Threading.Tasks;


    using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

    public class UserController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        private readonly JandayaDbContext dbContext;

        public IUserServices UserService { get; }

        public UserController(JandayaDbContext dbContext, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IUserServices userService)
        {
            this.dbContext = dbContext;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.UserService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(CreateUserBindingModel createUserModel)
        {
            var returnUrl = "/Home/Index";

            if (ModelState.IsValid)
            {
                var countryFromDb = dbContext.Countries.SingleOrDefault(s => s.Name == createUserModel.Country);

                var user = new User
                {
                    UserName = createUserModel.UserName,
                    FirstName = createUserModel.FirstName,
                    LastName = createUserModel.LastName,
                    Email = createUserModel.Email,
                    CountryId = countryFromDb.Id,
                };

                //dbContext.Users.Add(user);
                //await dbContext.SaveChangesAsync();

                var result = await _userManager.CreateAsync(user, createUserModel.Password);
                if (result.Succeeded)
                {
                    if (_userManager.Users.Count() == 1)
                    {
                        await _userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, GlobalConstants.EmployeeRoleName);
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return Redirect(returnUrl);
                }
            }

            return Redirect("/");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login() => View();

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginUserBindingModel loginUserModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(loginUserModel);
            }

            var result = this.UserService.LogUser(loginUserModel);

            if (result != SignInResult.Success)
            {
                this.ViewData[GlobalConstants.ModelError] = GlobalConstants.LoginError;
                return this.View(loginUserModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}