namespace Jandaya.Services
{
    using Microsoft.AspNetCore.Identity;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Data.Models;
    using System.Threading.Tasks;

    public interface IUserServices
    {
        SignInResult LogUser(LoginUserBindingModel loginModel);

        Task<User> GetUserById(string id);
    }
}
