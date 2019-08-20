namespace Jandaya.Services
{
    using Jandaya.Data.Models.BindingModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminService
    {
        Task<IEnumerable<TViewModel>> GetAllActiveUsers<TViewModel>();

        Task<string> GetRoleNameById(string roleName);

        Task SetResourceGroup(string id, SetResourceGroupBindingModel model);

        Task<SetResourceGroupBindingModel> GetUserAndResourceGroups(string id);
    }
}
