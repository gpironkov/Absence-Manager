namespace Jandaya.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using Jandaya.Services;
    using System.Collections.Generic;
    using Jandaya.Data;
    using System.Linq;

    public class ResourceGroupsViewComponent : ViewComponent
    {
        private readonly JandayaDbContext dbContext;

        public ResourceGroupsViewComponent(JandayaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            return this.View(new ResourceGroupViewComponentViewModel
            {
                Name = this.GetResourceGroups()
            });
        }

        private IEnumerable<string> GetResourceGroups()
        {
            var resourceGroups = this.dbContext.ResourceGroups.Select(x => x.Name).ToList();

            return resourceGroups;
        }
    }

    public class ResourceGroupViewComponentViewModel
    {
        //public int Id { get; set; }

        public IEnumerable<string> Name { get; set; }
    }
}
