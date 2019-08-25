namespace Jandaya.Services
{
    using Jandaya.Data;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminServices : IAdminService
    {
        private readonly JandayaDbContext dbContext;
        private readonly IUserServices userService;

        public AdminServices(JandayaDbContext dbContext, IUserServices userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public async Task<IEnumerable<TViewModel>> GetAllActiveUsers<TViewModel>()
        {
            var activeUsers = this.dbContext.Users
                .Include(u => u.Roles)
                .Include(u => u.Country)
                .Where(u => u.IsDeleted == false)
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName);

            foreach (var user in activeUsers)
            {
                //user.Country.Name = await GetContryNameById(user.CountryId);

                foreach (var role in user.Roles)
                {
                    var roleName = await this.GetRoleNameById(role.RoleId);
                    role.RoleId = roleName;
                }
            }

            return activeUsers.To<TViewModel>().ToList();
        }

        public Task<string> GetRoleNameById(string roleId)
        {
            var userRoleName = this.dbContext.Roles
                .FirstOrDefault(r => r.Id == roleId)
                .Name;

            return Task.FromResult(userRoleName);
        }

        private IEnumerable<string> GetResourceGroups()
        {
            var resourceGroups = this.dbContext.ResourceGroups.Select(x => x.Name).ToList();

            return resourceGroups;
        }

        private IEnumerable<string> GetUserRoles()
        {
            var roles = this.dbContext.Roles.Select(x => x.Name).ToList();

            return roles;
        }

        public async Task<SetResourceGroupBindingModel> GetUserAndResourceGroups(string id)
        {
            var user = await this.userService.GetUserById(id);
            var model = new SetResourceGroupBindingModel();

            model.FullName = $"{user.FirstName} {user.LastName}";
            model.Name = GetResourceGroups().ToList();

            return model;
        }

        public async Task SetResourceGroup(string userId, SetResourceGroupBindingModel model)
        {
            var userToUpdate = await this.userService.GetUserById(userId);
            var resGroupFromDb = dbContext.ResourceGroups.SingleOrDefault(s => s.Name == model.Name.FirstOrDefault());

            userToUpdate.ResourceGroupId = resGroupFromDb.Id;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<SetUserRoleBindingModel> GetUserAndRoles(string id)
        {
            var user = this.dbContext.Users
               .Include(u => u.Roles)
               .Where(u => u.IsDeleted == false)
               .Where(u => u.Id == id)
               .SingleOrDefault();

            var model = new SetUserRoleBindingModel();

            model.FullName = $"{user.FirstName} {user.LastName}";
            model.Roles = GetUserRoles().ToList();

            foreach (var role in user.Roles)
            {
                var roleName = await this.GetRoleNameById(role.RoleId);
                model.CurrentUserRole = roleName;
            }
            model.Roles.Remove(model.CurrentUserRole);

            return model;
        }

        public async Task SetUserRole(string id, SetUserRoleBindingModel model)
        {
            var user = this.dbContext.Users
               .Include(u => u.Roles)
               .Where(u => u.IsDeleted == false)
               .Where(u => u.Id == id)
               .SingleOrDefault();            

            var userRoleFromDb = dbContext.UserRoles.SingleOrDefault(ur => ur.UserId == user.Id);
            this.dbContext.UserRoles.Attach(userRoleFromDb);
            this.dbContext.UserRoles.Remove(userRoleFromDb);
            this.dbContext.SaveChanges();

            var chosenRole = dbContext.Roles.SingleOrDefault(r => r.Name == model.Roles.FirstOrDefault());
            
            userRoleFromDb.RoleId = chosenRole.Id;
            userRoleFromDb.UserId = user.Id;
            this.dbContext.Add(userRoleFromDb);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
