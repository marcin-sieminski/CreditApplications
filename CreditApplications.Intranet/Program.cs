using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Logic;
using CreditApplications.ApplicationServices.Mappings;
using CreditApplications.DataAccess;
using CreditApplications.DataAccess.Entities;
using CreditApplications.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(120);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAutoMapper(typeof(CreditApplicationProfile).Assembly);
builder.Services.AddDbContext<CreditApplicationsDbContext>(cfg =>
{
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("CreditApplicationsConnection")).EnableSensitiveDataLogging();
});
builder.Services.AddScoped<IRepository<CreditApplication>, CreditApplicationsRepository>();

builder.Services.AddScoped<ICreditApplicationLogic, CreditApplicationLogic>();

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
app.UseCookiePolicy();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Intranet}/{action=Index}/{id?}");

app.Run();
