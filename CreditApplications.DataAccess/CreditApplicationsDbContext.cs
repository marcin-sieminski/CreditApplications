using CreditApplications.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.DataAccess;

public class CreditApplicationsDbContext : DbContext
{
    public CreditApplicationsDbContext() 
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=CreditApplications;Integrated Security=True;Encrypt=False");
        }
    }

    public DbSet<ApplicationStatus> ApplicationStatus => Set<ApplicationStatus>();
    public DbSet<CreditApplication> CreditApplication => Set<CreditApplication>();
    public DbSet<Customer> Customer => Set<Customer>();
    public DbSet<Department> Department => Set<Department>();
    public DbSet<Employee> Employee => Set<Employee>();
    public DbSet<ProductType> ProductType => Set<ProductType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DbSeederHelper.DbSeeder(modelBuilder);
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
                    entry.Entity.StatusId = 1;
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
                    entry.Entity.StatusId = 0;
                    entry.State = EntityState.Modified;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}