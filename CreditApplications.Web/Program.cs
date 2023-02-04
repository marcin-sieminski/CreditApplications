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
builder.Services.AddScoped<IRepository<Customer>, CustomersRepository>();
builder.Services.AddScoped<IRepository<ProductType>, ProductTypeRepository>();
builder.Services.AddScoped<IRepository<ApplicationStatus>, ApplicationsStatusRepository>();
builder.Services.AddScoped<IRepository<Department>, DepartmentRepository>();
builder.Services.AddScoped<IRepository<Role>, RoleRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Collateral>, CollateraleRepository>();

builder.Services.AddScoped<ICreditApplicationLogic, CreditApplicationLogic>();
builder.Services.AddScoped<ICustomerLogic, CustomerLogic>();
builder.Services.AddScoped<IProductTypeLogic, ProductTypeLogic>();
builder.Services.AddScoped<IApplicationStatusLogic, ApplicationStatusLogic>();
builder.Services.AddScoped<IDepartmentLogic, DepartmentLogic>();
builder.Services.AddScoped<IRoleLogic, RoleLogic>();
builder.Services.AddScoped<IEmploeeLogic, EmployeeLogic>();
builder.Services.AddScoped<ICollateralLogic, CollateralLogic>();


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
    pattern: "{controller=CreditApplication}/{action=Index}/{id?}");

app.Run();
