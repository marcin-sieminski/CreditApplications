using CreditApplications.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CreditApplications.DataAccess;

public class CreditApplicationsDbContext : IdentityDbContext
{
    public CreditApplicationsDbContext(DbContextOptions<CreditApplicationsDbContext> options) : base(options)
    {

    }

    public DbSet<ApplicationStatus> ApplicationStatuses => Set<ApplicationStatus>();
    public DbSet<CreditApplication> CreditApplications => Set<CreditApplication>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<ProductType> ProductTypes => Set<ProductType>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<ProcessRole> Roles => Set<ProcessRole>();
    public DbSet<Collateral> Collaterals => Set<Collateral>();
    public DbSet<Page> Pages => Set<Page>();
    public DbSet<Article> Articles => Set<Article>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CreditApplication>(eb =>
            eb.HasOne(o => o.Customer)
                .WithMany(m => m.CreditApplications)
                .HasForeignKey(fk => fk.CustomerId)
                );

        modelBuilder.Entity<CreditApplication>(eb =>
            eb.HasMany(m => m.Employees)
                .WithMany(m => m.CreditApplications)
                .UsingEntity<CreditApplicationEmployee>(
                    m => m.HasOne(o => o.Employee)
                        .WithMany()
                        .HasForeignKey(fk => fk.EmployeeId),
                    m => m.HasOne(o => o.CreditApplication)
                        .WithMany()
                        .HasForeignKey(fk => fk.CreditApplicationId),

                    pk =>
                    {
                        pk.HasKey(x => x.Id);
                    }
                ));
    }
}