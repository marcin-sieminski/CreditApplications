using CreditApplications.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.DataAccess.Repositories;

public class CustomersRepository : IRepository<Customer>
{
    private readonly CreditApplicationsDbContext _context;
    private readonly DbSet<Customer> _entities;

    public CustomersRepository(CreditApplicationsDbContext context)
    {
        _context = context;
        _entities = context.Set<Customer>();
    }

    public async Task<List<Customer>> GetAll()
    {
        return await _entities
            .Where(x => x.IsActive)
            .ToListAsync();
    }

    public async Task<Customer> GetById(int id)
    {
        return await _entities
            .Where(x => x.IsActive)
            .SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Customer> Create(Customer entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        var entityEntry = _entities.Add(entity);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<int> Update(Customer entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        var dbEntity = _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == entity.Id);
        if (dbEntity is not null)
        {
            entity.Created = dbEntity.Created;
            entity.CreatedBy = dbEntity.CreatedBy;
        }
        _entities.Update(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var entity = _entities.SingleOrDefault(e => e.Id == id);
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        _entities.Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> GetCount()
    {
        return await _entities.CountAsync(x => x!.IsActive == true);
    }

    public bool TryEntityExists(int id)
    {
        return _entities.Any(x => x.Id == id);
    }
}