using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess;
using CreditApplications.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.ApplicationServices.Domain.Logic;

public class CreditApplicationLogic : ICreditApplicationLogic
{
    private readonly IRepository<DataAccess.Entities.CreditApplication> _repository;
    private readonly IMapper _mapper;
    private readonly CreditApplicationsDbContext _context;

    public CreditApplicationLogic(IRepository<DataAccess.Entities.CreditApplication> repository, IMapper mapper, CreditApplicationsDbContext dbContext)
    {
        _repository = repository;
        _mapper = mapper;
        _context = dbContext;
    }

    public async Task<List<CreditApplication>> GetAll()
    {
        var creditApplicationsFromDb = await _repository.GetAll();
        var creditApplications = _mapper.Map<List<CreditApplication>>(creditApplicationsFromDb);
        return creditApplications;
    }

    public async Task<CreditApplication> GetById(int id)
    {
        var creditApplicationFromDb = await _repository.GetById(id);
        var creditApplication = _mapper.Map<CreditApplication>(creditApplicationFromDb);
        return creditApplication;
    }

    public async Task<int> Create(CreditApplication entity)
    {
        var dbEntity = _mapper.Map<DataAccess.Entities.CreditApplication>(entity);
        dbEntity.Created = DateTime.Now;
        dbEntity.Modified = DateTime.Now;
        dbEntity.IsActive = true;
        dbEntity.ApplicationStatusId = 2;
        var idCreated = await _repository.Create(dbEntity);
        return idCreated;
    }

    public async Task<int> Update(CreditApplication entity)
    {
        var entityForDb = _mapper.Map<DataAccess.Entities.CreditApplication>(entity);
        entityForDb.Modified = DateTime.Now;
        entityForDb.IsActive = true;
        entityForDb.ApplicationStatusId = 3;
        var id = await _repository.Update(entityForDb);
        return id;
    }

    public async Task<int> Delete(int id)
    {
        var idDeleted = await _repository.Delete(id);
        return idDeleted;
    }

    public async Task<int> GetCount()
    {
        return await _repository.GetCount();
    }

    public async Task<CreditApplication> Initialize(CreditApplication model)
    {
        model.AvailableCustomers = await _context.Customers.Where(x => x.IsActive).ToListAsync();
        model.AvailableProductTypes = await _context.ProductTypes.Where(x => x.IsActive).ToListAsync();
        model.AvailableApplicationStatuses = await _context.ApplicationStatuses.Where(x => x.IsActive).ToListAsync();
        model.AvailableEmployees = await _context.Employees.Where(x => x.IsActive).ToListAsync();
        return model;
    }
}
