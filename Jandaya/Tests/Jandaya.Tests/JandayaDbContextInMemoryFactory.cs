namespace Jandaya.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Jandaya.Data;
    using System;

    public class JandayaDbContextInMemoryFactory
    {
        public static JandayaDbContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<JandayaDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            return new JandayaDbContext(options);
        }
    }
}
