using System.Text.Json.Serialization;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Logic;
using CreditApplications.ApplicationServices.Mappings;
using CreditApplications.DataAccess;
using CreditApplications.DataAccess.Entities;
using CreditApplications.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using CreditApplication = CreditApplications.DataAccess.Entities.CreditApplication;
using Customer = CreditApplications.DataAccess.Entities.Customer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(CreditApplicationProfile).Assembly);
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);;
builder.Services.AddDbContext<CreditApplicationsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CreditApplicationsConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<CreditApplication>, CreditApplicationsRepository>();
builder.Services.AddScoped<IRepository<Customer>, CustomersRepository>();
builder.Services.AddScoped<IRepository<ApplicationStatus>, ApplicationsStatusRepository>();
builder.Services.AddScoped<IRepository<ProductType>, ProductTypeRepository>();
builder.Services.AddScoped<ICreditApplicationLogic, CreditApplicationLogic>();
builder.Services.AddScoped<ICustomerLogic, CustomerLogic>();
builder.Services.AddScoped<IProductTypeLogic, ProductTypeLogic>();
builder.Services.AddScoped<IApplicationStatusLogic, ApplicationStatusLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
