namespace Jandaya.Controllers.Administration
{
    using System.Threading.Tasks;
    using Jandaya.Data.ViewModels;
    using Jandaya.Services;
    using Microsoft.AspNetCore.Mvc;

    public class UserManageController : AdminController
    {
        private readonly IAdminService adminService;

        public UserManageController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public async Task<IActionResult> GetUserData()
        {
            var activeUsers = await adminService.GetAllActiveUsers<UsersAllViewModel>();
            return this.View(activeUsers);
        }
    }
}