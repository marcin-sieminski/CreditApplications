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
            .ToListAsync();
    }

    public async Task<Customer> GetById(int id)
    {
        return await _entities
            .SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<int> Insert(Customer entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        _entities.Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update(Customer entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
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
}