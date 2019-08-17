namespace Jandaya.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminService
    {
        Task<IEnumerable<TViewModel>> GetAllActiveUsers<TViewModel>();

        Task<string> GetRoleNameById(string roleName);
    }
}
