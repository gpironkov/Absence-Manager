namespace Jandaya.Services
{
    using Jandaya.Data;
    using Jandaya.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminServices : IAdminService
    {
        private readonly JandayaDbContext dbContext;

        public AdminServices(JandayaDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        //public Task<string> GetContryNameById(int countryId)
        //{
        //    var countryName = this.dbContext.Countries
        //        .FirstOrDefault(c => c.Id == countryId)
        //        .Name;

        //    return Task.FromResult(countryName);
        //}
    }
}
