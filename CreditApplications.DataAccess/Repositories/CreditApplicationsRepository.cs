using CreditApplications.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.DataAccess.Repositories;

public class CreditApplicationsRepository : IRepository<CreditApplication>
{
    private readonly CreditApplicationsDbContext _context;
    private readonly DbSet<CreditApplication?> _entities;

    public CreditApplicationsRepository(CreditApplicationsDbContext context)
    {
        _context = context;
        _entities = context.Set<CreditApplication>();
    }

    public async Task<List<CreditApplication>> GetAll()
    {
        return await _entities
            .Include(x => x.Customer)
            .Include(x => x.ApplicationStatus)
            .Include(x => x.Employees)
            .Include(x => x.ProductType)
            .ToListAsync();
    }

    public async Task<CreditApplication?> GetById(int id)
    {
        return await _entities
            .Include(x => x.Customer)
            .Include(x => x.Employees)
            .Include(x => x.ApplicationStatus)
            .Include(x => x.ProductType)
            .SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<int> Insert(CreditApplication entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        _entities.Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<Task<int>> Update(CreditApplication entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        _entities.Update(entity);
        return _context.SaveChangesAsync();
    }

    public async Task<Task<int>> Delete(int id)
    {
        CreditApplication? entity = _entities.SingleOrDefault(e => e.Id == id);
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        _entities.Remove(entity);
        return _context.SaveChangesAsync();
    }

    public int GetActiveApplicationsNumber
    {
        get => _entities.Count(x => x!.IsActive == true);
    }
}