namespace Jandaya.Services
{
    using Jandaya.Data.Models.BindingModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IResourceGroupService
    {
        Task<bool> AddNewResourceGroup(AddNewResourceGroupBindingModel bindingModel);
    }
}
