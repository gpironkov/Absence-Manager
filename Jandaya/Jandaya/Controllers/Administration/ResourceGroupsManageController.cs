namespace Jandaya.Controllers.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Jandaya.Data.Models;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Services;
    using Microsoft.AspNetCore.Mvc;

    public class ResourceGroupsManageController : Controller
    {
        public IResourceGroupService ResGroupService { get; }

        public ResourceGroupsManageController(IResourceGroupService service)
        {
            this.ResGroupService = service;
        }

        public IActionResult ResourceGroups() => View();

        [HttpPost]
        public async Task<IActionResult> ResourceGroups(AddNewResourceGroupBindingModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
            }

            await this.ResGroupService.AddNewResourceGroup(bindingModel);

            return Redirect("/");
        }
    }
}