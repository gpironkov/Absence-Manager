using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jandaya.Data;
using Jandaya.Data.Models;
using Jandaya.Data.Models.BindingModels;

namespace Jandaya.Services
{
    public class ResourceGroupService : IResourceGroupService
    {
        private readonly JandayaDbContext dbContext;

        public ResourceGroupService(JandayaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddNewResourceGroup(AddNewResourceGroupBindingModel bindingModel)
        {
            var resGroup = new ResourceGroup();

            resGroup.Name = bindingModel.Name;

            this.dbContext.ResourceGroups.Add(resGroup);
            var result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
