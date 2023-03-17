using CreditApplications.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.DataAccess.Repositories;

public class EmployeeRepository : IRepository<Employee>
{
    private readonly CreditApplicationsDbContext _context;
    private readonly DbSet<Employee> _entities;

    public EmployeeRepository(CreditApplicationsDbContext context)
    {
        _context = context;
        _entities = context.Set<Employee>();
    }

    public async Task<List<Employee>> GetAll()
    {
        return await _entities
            .Where(x => x.IsActive)
            .Include(x => x.Department)
            .Include(x => x.Role)
            .ToListAsync();
    }

    public async Task<Employee> GetById(int id)
    {
        return await _entities
            .Where(x => x.IsActive)
            .Include(x => x.Department)
            .Include(x => x.Role)
            .SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Employee> Create(Employee entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        var entityEntry = _entities.Add(entity);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<int> Update(Employee entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        var dbEntity = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == entity.Id);
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