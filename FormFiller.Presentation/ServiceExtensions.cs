using FormFiller.Infrasctructure.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Xml.XPath;

namespace FormFiller.Presentation
{
    public static class ServiceExtensions
    {
        public static void ConfigureDb(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbString");
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }
    }
}
