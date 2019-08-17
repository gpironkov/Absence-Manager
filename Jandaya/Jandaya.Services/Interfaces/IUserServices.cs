namespace Jandaya.Services
{
    using Microsoft.AspNetCore.Identity;
    using Jandaya.Data.Models.BindingModels;

    public interface IUserServices
    {
        SignInResult LogUser(LoginUserBindingModel loginModel);
    }
}
