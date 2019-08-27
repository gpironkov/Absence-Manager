namespace Jandaya.Services
{
    using Microsoft.AspNetCore.Identity;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Data.Models;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IUserServices
    {
        SignInResult LogUser(LoginUserBindingModel loginModel);

        Task<User> GetUserById(string id);

        Task<int> GetDaysLeftById(string userId);

        Task<string> GetCurrentUserId();

        Task<IEnumerable<string>> GetUserIdsByResGroupId(string resGroupId);

        string GetResGroupId();

        Task<string> GetRoleIdByName(string roleName);
    }
}
