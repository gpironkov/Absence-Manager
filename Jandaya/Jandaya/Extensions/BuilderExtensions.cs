namespace Jandaya.Extensions
{
    using Jandaya.Data;
    using Jandaya.Data.Seeding;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Reflection;

    public static class BuilderExtension
    {
        public static void UsedatabaseSeeding(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<JandayaDbContext>())
                {

                    Assembly.GetAssembly(typeof(JandayaDbContext))
                         .GetTypes()
                         .Where(type => typeof(ISeeder).IsAssignableFrom(type))
                         .Where(type => type.IsClass)
                         .Select(type => (ISeeder)serviceScope.ServiceProvider.GetRequiredService(type))
                         .ToList()
                         .ForEach(seeder => seeder.Seed());
                }
            }
        }
    }
}
