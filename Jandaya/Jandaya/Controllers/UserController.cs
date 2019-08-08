namespace Jandaya.Controllers
{
    using Jandaya.Common;
    using Jandaya.Data;
    using Jandaya.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        private readonly JandayaDbContext dbContext;

        public UserController(JandayaDbContext dbContext, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            this.dbContext = dbContext;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Register() => View();

        [HttpPost]
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
    }
}