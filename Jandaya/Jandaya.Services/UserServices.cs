namespace Jandaya.Services
{
    using Jandaya.Data;
    using Jandaya.Data.Models;
    using Jandaya.Data.Models.BindingModels;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;

    public class UserServices : IUserServices
    {
        private readonly JandayaDbContext dbContext;
        protected SignInManager<User> SignInManager { get; } //SignInManager<JandayaUserModel>

        public UserServices(JandayaDbContext dbContext, SignInManager<User> SignInManager)
        {
            this.dbContext = dbContext;
            this.SignInManager = SignInManager;
        }        

        public SignInResult LogUser(LoginUserBindingModel loginModel)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.UserName == loginModel.UserName);

            if (user == null)
            {
                return SignInResult.Failed;
            }

            var password = loginModel.Password;
            var result = this.SignInManager.PasswordSignInAsync(user, password, true, false).Result;

            return result;
        }        
    }
}
