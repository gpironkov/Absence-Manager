using Jandaya.Data.Models.BindingModels;
using System.Threading.Tasks;

namespace Jandaya.Services
{
    public interface IResourceGroupService
    {
        Task<bool> AddNewResourceGroup(AddNewResourceGroupBindingModel bindingModel);
    }
}
