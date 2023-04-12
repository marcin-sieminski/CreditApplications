using CreditApplications.DataAccess.Entities;
using CreditApplications.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CreditApplications.DataAccess.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CreditApplicationsDbContext>(cfg =>
        {
            cfg.UseSqlServer(configuration.GetConnectionString("CreditApplicationsConnection")).EnableSensitiveDataLogging();
        });
        services.AddScoped<IRepository<Article>, ArticleRepository>();
        services.AddScoped<IRepository<Page>, PageRepository>();
        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CreditApplicationsDbContext>();
    }
}