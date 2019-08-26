namespace Jandaya.Controllers.Administration
{
    using Jandaya.Common;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public abstract class AdminController : BaseController
    {
    }
}