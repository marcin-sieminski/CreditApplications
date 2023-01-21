using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.DataAccess.Repositories;

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

    public async Task<int> Insert(Customer model)
    {
        var dbEntity = _mapper.Map<DataAccess.Entities.Customer>(model);
        var id = await _repository.Insert(dbEntity);
        return id;
    }

    public async Task<int> Update(Customer model)
    {
        var dbEntity = _mapper.Map<DataAccess.Entities.Customer>(model);
        var id = await _repository.Update(dbEntity);
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
}
