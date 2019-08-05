namespace Jandaya.Data.Seeding
{
    using Jandaya.Common;
    using Jandaya.Data.Models;
    using System.Linq;

    public class UserRolesSeeder : ISeeder
    {
        private readonly JandayaDbContext context;

        public UserRolesSeeder(JandayaDbContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new Role { Name = GlobalConstants.AdministratorRoleName, NormalizedName = "ADMIN" });
                context.Roles.Add(new Role { Name = GlobalConstants.ManagerRoleName, NormalizedName = "MANAGER" });
                context.Roles.Add(new Role { Name = GlobalConstants.EmployeeRoleName, NormalizedName = "USER" });
            }

            context.SaveChanges();
        }
    }
}
