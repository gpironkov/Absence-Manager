namespace Jandaya.Tests
{
    using Jandaya.Data;
    using Jandaya.Data.Models;
    using Jandaya.Services;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class AdminServiceTests
    {
        private IAdminService adminService;
        //private IUserService userService;        

        [Trait("service", "AdminService")]
        [Fact]
        public async Task GetUserRolesById_ShouldReturnCorrectResults()
        {
            var userId = "123";

            //var actualResults = await this.adminService.GetUserRolesById(userId);

            //Assert.InRange(() =>
            //{
            //    Assert.IsTrue(actualResults.Resource);
            //    Assert.IsTrue(actualResults.Approver);
            //    Assert.IsFalse(actualResults.Admin);
            //    Assert.IsFalse(actualResults.Planner);
            //});
        }
    }
}
