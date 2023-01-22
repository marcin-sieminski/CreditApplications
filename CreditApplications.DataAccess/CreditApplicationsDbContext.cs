using CreditApplications.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CreditApplications.DataAccess;

public class CreditApplicationsDbContext : DbContext
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


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = string.Empty;
                    entry.Entity.Created = DateTime.UtcNow;
                    entry.Entity.IsActive = true;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedBy = string.Empty;
                    entry.Entity.Modified = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entry.Entity.ModifiedBy = string.Empty;
                    entry.Entity.Modified = DateTime.UtcNow;
                    entry.Entity.Inactivated = DateTime.UtcNow;
                    entry.Entity.InactivatedBy = string.Empty;
                    entry.Entity.IsActive = false;
                    entry.State = EntityState.Modified;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}