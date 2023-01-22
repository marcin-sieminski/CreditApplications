using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.DataAccess.Repositories;
using Customer = CreditApplications.ApplicationServices.Domain.Models.Customer;

namespace CreditApplications.ApplicationServices.Domain.Logic;

public class CustomerLogic : ICustomerLogic
{
    private readonly IRepository<DataAccess.Entities.Customer> _repository;
    private readonly IMapper _mapper;

    public CustomerLogic(IRepository<DataAccess.Entities.Customer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<Customer>> GetAll()
    {
        var dbEntities = await _repository.GetAll();
        var model = _mapper.Map<List<Customer>>(dbEntities);
        return model;
    }

    public async Task<Customer> GetById(int id)
    {
        var dbEntity = await _repository.GetById(id);
        var model = _mapper.Map<Customer>(dbEntity);
        return model;
    }

    public async Task<int> Create(Customer model)
    {
        var dbEntity = _mapper.Map<DataAccess.Entities.Customer>(model);
        dbEntity.Created = DateTime.Now;
        dbEntity.Modified = DateTime.Now;
        dbEntity.IsActive = true;
        var id = await _repository.Create(dbEntity);
        return id;
    }

    public async Task<int> Update(Customer model)
    {
        var entityForDb = _mapper.Map<DataAccess.Entities.Customer>(model);
        entityForDb.Modified = DateTime.Now;
        entityForDb.IsActive = true;
        var id = await _repository.Update(entityForDb);
        return id;
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
}
