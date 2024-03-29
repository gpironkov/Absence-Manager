﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jandaya.Data;
using Jandaya.Data.Models;
using Jandaya.Data.Models.BindingModels;
using Jandaya.Services.Interfaces;

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

            if (this.GetResourceGroups().Contains(resGroup.Name))
            {
                return false;
            }

            this.dbContext.ResourceGroups.Add(resGroup);            
            var result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        private IEnumerable<string> GetResourceGroups()
        {
            var resourceGroups = this.dbContext.ResourceGroups.Select(x => x.Name).ToList();

            return resourceGroups;
        }
    }
}
