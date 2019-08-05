namespace Jandaya.Controllers
{
    using Jandaya.Data;
    using Jandaya.Data.Models;
    using Jandaya.Data.Repositories;
    using Jandaya.Data.ViewModels;
    using Jandaya.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class UserController : Controller
    {
        private readonly JandayaDbContext dbContext;

        public UserController(JandayaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(CreateUserBindingModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("User/Register");
            }

            CountryService cs = new CountryService(dbContext);
            var countryIds = cs.GetCountryIds();

            var countryFromDb = dbContext.Countries.SingleOrDefault(s => s.Name == createUserModel.Country);
            User user = new User
            {
                UserName = createUserModel.UserName,
                PasswordHash = createUserModel.Password,
                //PasswordHash = createUserModel.ConfirmPassword,
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                Email = createUserModel.Email,
                //CountryId = createUserModel.CountryId,
                Country = countryFromDb,
            };

            dbContext.Add(user);
            dbContext.SaveChanges();

            return this.Redirect("/");
        }
    }
}