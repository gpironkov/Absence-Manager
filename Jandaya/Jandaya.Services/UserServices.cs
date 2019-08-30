namespace Jandaya.Services
{
    using Jandaya.Data;
    using Jandaya.Data.Models;
    using Jandaya.Data.Models.BindingModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class UserServices : IUserServices
    {
        private readonly JandayaDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        protected SignInManager<User> SignInManager { get; }

        public UserServices(JandayaDbContext dbContext, SignInManager<User> SignInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.SignInManager = SignInManager;
            this.httpContextAccessor = httpContextAccessor;
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

        public Task<User> GetUserById(string id)//////
        {
            var user = this.dbContext.Users.SingleOrDefault(u => u.Id == id);

            return Task.FromResult(user);
        }

        public Task<string> GetRoleIdByName(string roleName)
        {
            var resourceRoleId = this.dbContext.Roles
                .FirstOrDefault(x => x.Name == roleName)
                .Id;

            return Task.FromResult(resourceRoleId);
        }

        public Task<string> GetCurrentUserId()
        {
            var currentUser = this.httpContextAccessor
                .HttpContext
                .User
                .FindFirst(ClaimTypes.NameIdentifier)
                .Value;

            return Task.FromResult(currentUser);
        }

        public Task<int> GetDaysLeftById(string userId)
        {
            var daysLeft = this.dbContext.Users
                .SingleOrDefault(u => u.Id == userId)
                .DaysLeft;

            return Task.FromResult(daysLeft);
        }

        public async Task<IEnumerable<string>> GetUserIdsByResGroupId(string resGroupId)
        {
            var currentUser = await this.GetCurrentUserId();

            var userIds = this.dbContext.Users
                .Where(u => u.Id != currentUser)
                .Where(u => u.ResourceGroupId == resGroupId)
                .Select(u => u.Id)
                .ToList();

            return userIds.AsEnumerable();
        }

        public async Task<string> GetResGroupId()
        {
            var currentUser = await this.GetCurrentUserId();

            var resGroupId = this.dbContext.Users
                .FirstOrDefault(u => u.Id == currentUser)
                .ResourceGroupId;

            return resGroupId;
        }
    }
}
