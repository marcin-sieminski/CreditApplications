using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess;
using CreditApplications.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.ApplicationServices.Domain.Logic;

public class EmployeeLogic : IEmploeeLogic
{
    private readonly IRepository<DataAccess.Entities.Employee> _repository;
    private readonly IMapper _mapper;
    private readonly CreditApplicationsDbContext _context;
    
    public EmployeeLogic(IRepository<DataAccess.Entities.Employee> repository, IMapper mapper, CreditApplicationsDbContext context)
    {
        _repository = repository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<EmployeeModel>> GetAll()
    {
        var dbEntities = await _repository.GetAll();
        var model = _mapper.Map<List<EmployeeModel>>(dbEntities);
        return model;
    }

    public async Task<EmployeeModel> GetById(int id)
    {
        var dbEntity = await _repository.GetById(id);
        var model = _mapper.Map<EmployeeModel>(dbEntity);
        return model;
    }

    public async Task<DataAccess.Entities.Employee> Create(EmployeeModel model)
    {
        var dbEntity = _mapper.Map<DataAccess.Entities.Employee>(model);
        dbEntity.Created = DateTime.Now;
        dbEntity.Modified = DateTime.Now;
        dbEntity.IsActive = true;
        var entityCreated = await _repository.Create(dbEntity);
        return entityCreated;
    }

    public async Task<int> Update(EmployeeModel model)
    {
        var entityForDb = _mapper.Map<DataAccess.Entities.Employee>(model);
        entityForDb.Modified = DateTime.Now;
        entityForDb.IsActive = true;
        var idUpdated = await _repository.Update(entityForDb);
        return idUpdated;
    }

    public async Task<int> Inactivate(int id)
    {
        var dbEntity = await _repository.GetById(id);
        if (dbEntity is not null)
        {
            dbEntity.Inactivated = DateTime.Now;
            dbEntity.IsActive = false;
        }
        return await _repository.Update(dbEntity); 
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

    public bool EntityExists(int id)
    {
        return _repository.TryEntityExists(id);
    }

    public async Task<EmployeeModel> Initialize(EmployeeModel model)
    {
        model.AvailableDepartments = _mapper.Map<List<DepartmentModel>>(await _context.Departments.Where(x => x.IsActive).ToListAsync());
        model.AvailableRoles = _mapper.Map<List<RoleModel>>(await _context.Roles.Where(x => x.IsActive).ToListAsync());
        return model;
    }

}
