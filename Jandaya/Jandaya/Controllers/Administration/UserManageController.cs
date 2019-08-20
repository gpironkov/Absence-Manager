namespace Jandaya.Controllers.Administration
{
    using System.Linq;
    using System.Threading.Tasks;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Models;
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

        public async Task<IActionResult> SetResourceGroup(string id)
        {
            var resourceGroupForUpdate = await this.adminService.GetUserAndResourceGroups(id);

            return this.View(resourceGroupForUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> SetResourceGroup(SetResourceGroupBindingModel model, string id)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
            }

            await this.adminService.SetResourceGroup(id, model);

            return RedirectToAction(nameof(this.GetUserData));
        }
    }
}