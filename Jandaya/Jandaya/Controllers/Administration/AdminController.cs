using Jandaya.Common;
using Microsoft.AspNetCore.Authorization;

namespace Jandaya.Controllers.Administration
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public abstract class AdminController : BaseController
    {
    }
}