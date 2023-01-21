using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Logic;
using CreditApplications.ApplicationServices.Mappings;
using CreditApplications.DataAccess;
using CreditApplications.DataAccess.Entities;
using CreditApplications.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(CreditApplicationProfile).Assembly);
builder.Services.AddDbContext<CreditApplicationsDbContext>(cfg =>
{
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("CreditApplicationsConnection")).EnableSensitiveDataLogging();
});
builder.Services.AddScoped<IRepository<CreditApplication>, CreditApplicationsRepository>();
builder.Services.AddScoped<IRepository<Customer>, CustomersRepository>();
builder.Services.AddScoped<ICreditApplicationLogic, CreditApplicationLogic>();
builder.Services.AddScoped<ICustomerLogic, CustomerLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var ctx = services.GetRequiredService<CreditApplicationsDbContext>();
        ctx.Database.Migrate();
    }
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CreditApplications}/{action=Index}/{id?}");

app.Run();
