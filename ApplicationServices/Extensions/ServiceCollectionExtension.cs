using CreditApplications.ApplicationServices.ApplicationUser;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Logic;
using CreditApplications.ApplicationServices.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace CreditApplications.ApplicationServices.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CreditApplicationProfile).Assembly);
        services.AddScoped<IArticleLogic, ArticleLogic>();
        services.AddScoped<IPageLogic, PageLogic>();
        services.AddScoped<IUserContext, UserContext>();
    }
}