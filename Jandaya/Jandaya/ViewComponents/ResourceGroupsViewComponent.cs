namespace Jandaya.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using Jandaya.Services;
    using System.Collections.Generic;

    public class ResourceGroupsViewComponent : ViewComponent
    {
        private readonly IResourceGroupService resourceGroupsService;

        public ResourceGroupsViewComponent(IResourceGroupService resourceGroupsService)
        {
            this.resourceGroupsService = resourceGroupsService;
        }

        public IViewComponentResult Invoke()
        {
            return this.View(new ResourceGroupViewComponentViewModel
            {
                Name = resourceGroupsService.GetResourceGroups()
            });
        }
    }

    public class ResourceGroupViewComponentViewModel
    {
        //public int Id { get; set; }

        public IEnumerable<string> Name { get; set; }
    }
}
